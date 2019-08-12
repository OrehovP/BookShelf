using LogicLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataLayer;
using LogicLayer.PresentationModel;
using LogicLayer.PresentationModel.Forms;
using LogicLayer.Services;
using LogicLayer.FormValidators;

namespace BookShelf.Controllers
{
    public class GenreController : Controller
    {
        private IGenreService genreService;

        public GenreController(IGenreService service)
        {
            genreService = service;
        }
        
        public ActionResult Index()
        {
            IEnumerable<PGenre> pGenres = genreService.GetGenres();
            return View(pGenres);
        }

        [HttpGet]
        public ActionResult CreateEdit(Guid? id)
        {
            if (id != null)
                return View(genreService.GetGenre(id));
            else
                return View();
        }

        [HttpPost]
        public ActionResult CreateEdit(CreateEditGenre item)
        {
            var genreFormValidator = new GenreFormValidator();
            if (!genreFormValidator.Validate(item.Form))
            {
                foreach (var e in genreFormValidator.Exceptions)
                {
                    ModelState.AddModelError(e.Property, e.Message);
                }
                return View(genreService.GetGenre(item.Form.Id));
            }
            else
            {
                genreService.CreateEditGenre(item.Form);
                return RedirectToAction("Index");
            }
        }

        public ActionResult GetBooks(Guid? id)
        {
            return View(genreService.GetBooks(id));
        }

        [HttpGet]
        public ActionResult Delete(Guid id)
        {
            CreateEditGenre genre = genreService.GetGenre(id);
            return View(genre);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(Guid id)
        {
            genreService.DeleteGenre(id);
            return RedirectToAction("Index");
        }
    }
}
using LogicLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LogicLayer.PresentationModel;
using LogicLayer.FormValidators;
using LogicLayer.PresentationModel.Forms;

namespace BookShelf.Controllers
{
    public class AuthorController : Controller
    {
        private IAuthorService authorService;

        public AuthorController(IAuthorService service)
        {
            authorService = service;
        }
        
        public ActionResult Index()
        {
            IEnumerable<PAuthor> pAuthors = authorService.GetAuthors();
            return View(pAuthors);
        }

        [HttpGet]
        public ActionResult CreateEdit(Guid? id)
        {
            if (id != null)
                return View(authorService.GetAuthor(id));
            else
                return View();
        }

        [HttpPost]
        public ActionResult CreateEdit(HAuthorForm item)
        {
            var authorFormValidator = new AuthorFormValidator();
            if (!authorFormValidator.Validate(item.Form))
            {
                foreach (var e in authorFormValidator.Exceptions)
                {
                    ModelState.AddModelError(e.Property, e.Message);
                }
                return View(authorService.GetAuthor(item.Form.Id));
            }
            else
            {
                authorService.CreateEditAuthor(item.Form);
                return RedirectToAction("Index");
            }
        }

        public ActionResult GetBooks(Guid? id)
        {
            return View(authorService.GetBooks(id));
        }

        [HttpGet]
        public ActionResult Delete(Guid id)
        {
            CreateEditAuthor author = authorService.GetAuthor(id);
            return View(author);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(Guid id)
        {
            authorService.DeleteAuthor(id);
            return RedirectToAction("Index");
        }
    }
}
using LogicLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataLayer;
using LogicLayer.FormValidators;
using LogicLayer.PresentationModel;
using LogicLayer.PresentationModel.Forms;
using LogicLayer.Infrastructure;

namespace BookShelf.Controllers
{
    public class HomeController : Controller
    {
        private IBookService bookService;

        public HomeController(IBookService service)
        {
            bookService = service;
        }
        
        public ActionResult Index()
        {
            IEnumerable<PBook> pBooks = bookService.GetBooks();
            return View(pBooks);
        }

        [HttpGet]
        public ActionResult CreateEdit(Guid? id)
        {
            return View(bookService.GetBook(id));
        }

        [HttpPost]
        public ActionResult CreateEdit(HForm item)
        {
            var bookFormValidator = new BookFormValidator();
            if (!bookFormValidator.Validate(item.Form))
            {
                foreach (var e in bookFormValidator.Exceptions)
                {
                    ModelState.AddModelError(e.Property, e.Message);
                }
                return View(bookService.GetBook(item.Form.Id));
            }
            else
            {
                bookService.CreateEditBook(item.Form);
                return RedirectToAction("Index");
            }
        }

        public ActionResult GetGenres(Guid? id)
        {
            return View(bookService.GetGenres(id));
        }

        [HttpGet]
        public ActionResult Delete(Guid id)
        {
            CreateEditBook book = bookService.GetBook(id);
            return View(book);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(Guid id)
        {
            bookService.DeleteBook(id);
            return RedirectToAction("Index");
        }
    }
}
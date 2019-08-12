using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using DataLayer;
using DataLayer.Factories;
using DataLayer.Interfaces;
using LogicLayer.Infrastructure;
using LogicLayer.Interfaces;
using LogicLayer.PresentationModel;
using LogicLayer.PresentationModel.Forms;

namespace LogicLayer.Services
{
    public class BookService : IBookService
    {
        private IUnitOfWork DbOfWork { get; set; }

        public BookService(IUnitOfWork unit)
        {
            DbOfWork = unit;
        }

        public PAuthor GetAuthor(Guid? bookId)
        {
            var author = DbOfWork.Authors.Get(bookId.Value);
            return new PAuthor {DateBorn = author.DateBorn, Id = author.Id, Name = author.Name};
        }

        public CreateEditBook GetBook(Guid? id)
        {
            var ceBook = new CreateEditBook();
            if (id != null && id != Guid.Empty) // Изменение
            {
                Book book = DbOfWork.Books.Get(id);
                ceBook = new CreateEditBook
                {
                    Form = new BookForm
                    {
                        Id = book.Id, Name = book.Name, AuthorId = book.AuthorId,
                        Description = book.Description, PublicationDate = book.PublicationDate
                    }
                };
            }
            else // создание
            {
                ceBook = new CreateEditBook{Form = new BookForm()};
            }
            ceBook.Authors = from author in DbOfWork.Authors.GetAll()
                select new SelectListItem { Text = author.Name, Value = author.Id.ToString() };
            ceBook.Genres = from genre in DbOfWork.Genres.GetAll()
                select new PGenre {Id = genre.Id, Name = genre.Name};
            ceBook.Form.GenreIds = DbOfWork.BookGenres.GetGenresByBook(id);
            return ceBook;
        }

        public void CreateEditBook(BookForm item)
        {
            Book book = BookFactory.Build(item.Id, item.Name, item.AuthorId, item.PublicationDate, item.Description);
            if (item.Id != Guid.Empty) // изменение
            {
                DbOfWork.Books.Update(book);
                if (item.GenreIds != null)
                    DbOfWork.BookGenres.UpdateGenre(book.Id, item.GenreIds.ToList());
                else DbOfWork.BookGenres.UpdateGenre(book.Id, null);
            }
            else // создание
            {
                DbOfWork.Books.Create(book);
                if (item.GenreIds != null)
                    DbOfWork.BookGenres.UpdateGenre(book.Id, item.GenreIds.ToList());
                else DbOfWork.BookGenres.UpdateGenre(book.Id, null);
            }
            DbOfWork.Save();
        }

        public IEnumerable<PBook> GetBooks()
        {
            var books = DbOfWork.Books.GetAll().ToList();
            var authorIds = books.Select(x => x.AuthorId);
            var authors = DbOfWork.Authors.GetByIds(authorIds);

            IEnumerable<PBook> pBooks = books.Select(book => new PBook
            {
                Id = book.Id,
                Name = book.Name,
                AuthorName = authors[book.AuthorId],
                Description = book.Description,
                PublicationDate = book.PublicationDate
            });

            return pBooks;
        }

        public IEnumerable<PGenre> GetGenres(Guid? bookId)
        {
            var genreIds = DbOfWork.BookGenres.GetGenresByBook(bookId);
            var genres = DbOfWork.Genres;
            
            List<PGenre> pGenres = new List<PGenre>();
            foreach (var item in genreIds)
            {
                var genre = genres.Get(item.Value);
                pGenres.Add(new PGenre() { Id = genre.Id, Name = genre.Name });
            }

            return pGenres;
        }

        public void DeleteBook(Guid bookId)
        {
            DbOfWork.Books.Delete(bookId);
            DbOfWork.Save();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.WebSockets;
using DataLayer;
using DataLayer.Factories;
using DataLayer.Interfaces;
using LogicLayer.Interfaces;
using LogicLayer.PresentationModel;
using LogicLayer.PresentationModel.Forms;

namespace LogicLayer.Services
{
    public class GenreService : IGenreService
    {
        private IUnitOfWork DbOfWork { get; set; }

        public GenreService(IUnitOfWork unit)
        {
            DbOfWork = unit;
        }

        public CreateEditGenre GetGenre(Guid? id)
        {
            var ceGenre = new CreateEditGenre();
            if (id != null && id != Guid.Empty) // Изменение
            {
                Genre genre = DbOfWork.Genres.Get(id);
                ceGenre = new CreateEditGenre()
                {
                    Form = new GenreForm
                    {
                        Id = genre.Id,
                        Name = genre.Name
                    }
                };
            }
            else // создание
            {
                ceGenre = new CreateEditGenre();
            }

            return ceGenre;
        }

        public void CreateEditGenre(GenreForm item)
        {
            Genre genre = GenreFactory.Build(item.Id, item.Name);
            if (item.Id != Guid.Empty)
            {
                DbOfWork.Genres.Update(genre);
            }
            else
            {
                DbOfWork.Genres.Create(genre);
            }
            DbOfWork.Save();
        }

        public IEnumerable<PGenre> GetGenres()
        {
           var genres = DbOfWork.Genres.GetAll().ToList();

            IEnumerable<PGenre> pGenres = genres.Select(genre => new PGenre()
            {
                Id = genre.Id,
                Name = genre.Name
            });
            
            return pGenres;
        }

        public IEnumerable<PBook> GetBooks(Guid? genreId)
        {
            var booksIds = DbOfWork.BookGenres.GetBooksByGenre(genreId);
            var books = DbOfWork.Books;

            List<PBook> pBooks = new List<PBook>();
            foreach (var item in booksIds)
            {
                var book = books.Get(item.Value);
                pBooks.Add(new PBook() { Id = book.Id, Name = book.Name, AuthorId = book.AuthorId, AuthorName = DbOfWork.Authors.Get(book.AuthorId).Name, Description = book.Description, PublicationDate = book.PublicationDate });
            }

            return pBooks;
        }

        public void DeleteGenre(Guid genreId)
        {
            DbOfWork.Genres.Delete(genreId);
            DbOfWork.Save();
        }
    }
}

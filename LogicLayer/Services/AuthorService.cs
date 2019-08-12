using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;
using DataLayer.Factories;
using DataLayer.Interfaces;
using LogicLayer.Infrastructure;
using LogicLayer.Interfaces;
using LogicLayer.PresentationModel;
using LogicLayer.PresentationModel.Forms;

namespace LogicLayer.Services
{
    public class AuthorService : IAuthorService
    {
        private IUnitOfWork DbOfWork { get; set; }

        public AuthorService(IUnitOfWork unit)
        {
            DbOfWork = unit;
        }

        public IEnumerable<PAuthor> GetAuthors()
        {
            var authors = DbOfWork.Authors.GetAll().ToList();

            IEnumerable<PAuthor> pAuthors = authors.Select(author => new PAuthor()
            {
                Id = author.Id,
                Name = author.Name,
                DateBorn = author.DateBorn,
                CanDelete = GetBooks(author.Id).Count() == 0
            });
            
            return pAuthors;
        }

        public CreateEditAuthor GetAuthor(Guid? id)
        {
            var ceAuthor = new CreateEditAuthor();
            if (id != null && id != Guid.Empty) // Изменение
            {
                Author author = DbOfWork.Authors.Get(id);
                ceAuthor = new CreateEditAuthor()
                {
                    Form = new AuthorForm {
                    Id = author.Id,
                    Name = author.Name,
                    DateBorn = author.DateBorn
                    }
                };
            }
            else // создание
            {
                ceAuthor = new CreateEditAuthor(); 
            }
            
            return ceAuthor;
        }

        public void CreateEditAuthor(AuthorForm item)
        {
            Author author = AuthorFactory.Build(item.Id, item.Name, item.DateBorn);
            if (item.Id != Guid.Empty)
            {
                DbOfWork.Authors.Update(author);
            }
            else
            {
                DbOfWork.Authors.Create(author);
            }
            DbOfWork.Save();
        }

        public IEnumerable<PBook> GetBooks(Guid? authorId)
        {
            var books = DbOfWork.Books.GetAll().ToList();
            var authorBooks = books.Where(x => x.AuthorId == authorId);

            IEnumerable<PBook> pBooks = authorBooks.Select(book => new PBook
            {
                Id = book.Id,
                Name = book.Name,
                Description = book.Description,
                PublicationDate = book.PublicationDate
            });
            
            return pBooks;
        }

        public void DeleteAuthor(Guid authorId)
        {
            DbOfWork.Authors.Delete(authorId);
            DbOfWork.Save();
        }
    }
}

using DataLayer;
using LogicLayer.PresentationModel;
using LogicLayer.PresentationModel.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.Interfaces
{
    public interface IBookService
    {
        IEnumerable<PBook> GetBooks();
        void CreateEditBook(BookForm item);
        CreateEditBook GetBook(Guid? id);
        PAuthor GetAuthor(Guid? bookId);
        IEnumerable<PGenre> GetGenres(Guid? bookId);
        void DeleteBook(Guid bookId);
    }
}

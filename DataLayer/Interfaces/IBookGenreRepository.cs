using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Interfaces
{
    public interface IBookGenreRepository 
    {
        //IEnumerable<BookGenre> GetAll();
        IEnumerable<Guid?> GetBooksByGenre(Guid? genreId);
        IEnumerable<Guid?> GetGenresByBook(Guid? bookId);
        //IEnumerable<T> Find(Func<T, Boolean> predicate);
        //void Create(T item);
        void UpdateGenre(Guid? bookId, List<Guid?> genreIds);
        //void Delete(Guid id);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Interfaces
{
    public interface IUnitOfWork
    {
        IRepository<Book> Books { get; }
        IRepository<Author> Authors { get; }
        IRepository<Genre> Genres { get; }
        IBookGenreRepository BookGenres { get; }
        void Save();
    }
}

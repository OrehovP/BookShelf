using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Interfaces;

namespace DataLayer.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private Context db;

        public UnitOfWork(Context context)
        {
            db = context;
        }

        public IRepository<Book> Books
        {
            get { return new BookRepository(db); }
        }

        public IRepository<Author> Authors
        {
            get { return new AuthorRepository(db); }
        }


        public IRepository<Genre> Genres
        {
            get { return new GenreRepository(db); }
        }

        public IBookGenreRepository BookGenres
        {
            get { return new BookGenreRepository(db); }
        }

        public void Save()
        {
            db.SaveChanges();
        }
    }
}

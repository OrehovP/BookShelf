using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Interfaces;

namespace DataLayer.Repositories
{
    public class BookGenreRepository : IBookGenreRepository
    {
        private Context db;

        public BookGenreRepository(Context context)
        {
            db = context;
        }
        public IEnumerable<Guid?> GetBooksByGenre(Guid? genreId)
        {
            return db.BookGenre.Where(x => x.GenreId == genreId).Select(c => c.BookId);
        }

        public IEnumerable<Guid?> GetGenresByBook(Guid? bookId)
        {
            return db.BookGenre.Where(x => x.BookId == bookId).Select(c => c.GenreId);
        }

        public void UpdateGenre(Guid? bookId, List<Guid?> genreIds)
        {
            if (genreIds == null)
            {
                var delete = db.BookGenre.Where(x => x.BookId == bookId);
                foreach (var item in delete)
                    db.BookGenre.Remove(item);
            }
            else if (db.BookGenre.Any(x => x.BookId == bookId))
            {
                var idsInBase = db.BookGenre.Where(x => x.BookId == bookId).Select(c => c.GenreId);
                foreach (var genreId in genreIds)
                {
                    if (!idsInBase.Contains(genreId))
                        db.BookGenre.Add(new BookGenre { BookId = bookId, GenreId = genreId });
                }

                foreach (var idInBase in idsInBase)
                {
                    if (!genreIds.Contains(idInBase))
                        db.BookGenre.Remove(db.BookGenre.FirstOrDefault(x => x.BookId == bookId && x.GenreId == idInBase));

                }
            }
            else
            {
                foreach (var genreId in genreIds)
                    db.BookGenre.Add(new BookGenre { BookId = bookId, GenreId = genreId });
            }
                //db.Entry(db.BookGenre.Where(x=> x.BookId == bookId && x.GenreId == genreId)).State = EntityState.Modified;
        }
    }
}

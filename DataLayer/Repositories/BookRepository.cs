using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Interfaces;

namespace DataLayer.Repositories
{
    public class BookRepository : IRepository<Book>
    {
        private Context db;

        public BookRepository(Context context)
        {
            db = context;
        }

        public void Create(Book item)
        {
            db.Books.Add(item);
        }

        public void Delete(Guid id)
        {
            Book book = db.Books.Find(id);
            if (book != null)
                db.Books.Remove(book);
        }

        public IEnumerable<Book> Find(Func<Book, bool> predicate)
        {
            return db.Books.Where(predicate).ToList();
        }

        public Book Get(Guid? id)
        {
            return db.Books.Find(id);
        }

        public IEnumerable<Book> GetAll()
        {
            return db.Books;
        }

        public Dictionary<Guid, string> GetByIds(IEnumerable<Guid> ids)
        {
            var books = db.Books.Where(c => ids.Contains(c.Id)).ToList();
            var dictionary = new Dictionary<Guid, string> ();
            books.ForEach(a => dictionary.Add(a.Id, a.Name));
            return dictionary;
        }

        public void Update(Book item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
    }
}

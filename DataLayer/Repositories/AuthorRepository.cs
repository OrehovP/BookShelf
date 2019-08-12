using DataLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repositories
{
    public class AuthorRepository : IRepository<Author>
    {
        private Context db;

        public AuthorRepository(Context context)
        {
            db = context;
        }

        public void Create(Author item)
        {
            db.Authors.Add(item);
        }

        public void Delete(Guid id)
        {
            Author author = db.Authors.Find(id);
            if (author != null)
                db.Authors.Remove(author);
        }

        public IEnumerable<Author> Find(Func<Author, bool> predicate)
        {
            return db.Authors.Where(predicate).ToList();
        }

        public Author Get(Guid? id)
        {
            return db.Authors.Find(id);
        }

        public IEnumerable<Author> GetAll()
        {
            return db.Authors;
        }

        public void Update(Author item)
        {
            db.Entry(item).State = EntityState.Modified;
        }

        public Dictionary<Guid, string> GetByIds(IEnumerable<Guid> ids)
        {
            var authors = db.Authors.Where(c => ids.Contains(c.Id)).ToList();
            var dictionary = new Dictionary<Guid, string>();
            authors.ForEach(a => dictionary.Add(a.Id, a.Name));
            return dictionary;
        }
    }
}

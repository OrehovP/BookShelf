using DataLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repositories
{
    public class GenreRepository : IRepository<Genre>
    {
        private Context db;

        public GenreRepository(Context context)
        {
            db = context;
        }

        public void Create(Genre item)
        {
            db.Genres.Add(item);
        }

        public void Delete(Guid id)
        {
            Genre genre = db.Genres.Find(id);
            if (genre != null)
                db.Genres.Remove(genre);
        }

        public IEnumerable<Genre> Find(Func<Genre, bool> predicate)
        {
            return db.Genres.Where(predicate).ToList();
        }

        public Genre Get(Guid? id)
        {
            return db.Genres.Find(id);
        }

        public IEnumerable<Genre> GetAll()
        {
            return db.Genres;
        }

        public Dictionary<Guid, string> GetByIds(IEnumerable<Guid> ids)
        {
            var genres = db.Genres.Where(c => ids.Contains(c.Id)).ToList();
            var dictionary = new Dictionary<Guid, string>();
            genres.ForEach(a => dictionary.Add(a.Id, a.Name));
            return dictionary;
        }

        public void Update(Genre item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
    }
}

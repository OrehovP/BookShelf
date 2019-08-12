using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Factories
{
    public class AuthorFactory
    {
        public static Author Build(Guid id, string name, DateTime DateBorn)
        {
            Author author;
            if (id == Guid.Empty)
               author = new Author{Id = Guid.NewGuid(), Name = name, DateBorn = DateBorn};
            else
               author = new Author { Id = id, Name = name, DateBorn = DateBorn };
            return author;
        }
    }
}

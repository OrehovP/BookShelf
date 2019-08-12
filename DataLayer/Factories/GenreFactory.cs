using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Factories
{
    public class GenreFactory
    {
        public static Genre Build(Guid id, string name)
        {
            Genre genre;
            if (id == Guid.Empty)
                genre = new Genre {Id = Guid.NewGuid(), Name = name};
            else
                genre = new Genre { Id = id, Name = name};
            return genre;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Factories
{
    public class BookFactory
    {
        public static Book Build(Guid id, string name, Guid authorId, DateTime publicationDate, string description)
        {
            Book book;
            if (id == Guid.Empty)
                book = new Book{Id = Guid.NewGuid(), Name = name, AuthorId = authorId, PublicationDate = publicationDate, Description = description};
            else
                book = new Book { Id = id, Name = name, AuthorId = authorId, PublicationDate = publicationDate, Description = description };
            return book;
        }
    }
}

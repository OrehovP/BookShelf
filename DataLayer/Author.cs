using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class Author
    {
        [Key]
        public Guid Id { get; set; }

        [MaxLength(100)]
        public string Name { get; set; }

        public DateTime DateBorn { get; set; }

        protected ICollection<Book> Books { get; set; }
    }
}

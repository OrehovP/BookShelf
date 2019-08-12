using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class Book
    {
        [Key]
        public Guid Id { get; set; }

        [MaxLength(100)]
        public string Name { get; set; }

        public DateTime PublicationDate { get; set; }

        [MaxLength(1000)]
        public string Description { get; set; }

        public Guid AuthorId { get; set; }

        [ForeignKey("AuthorId")]
        public virtual Author Author { get; set; }

        protected ICollection<Genre> Genres { get; set; }
    }
}

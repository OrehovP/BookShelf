using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class BookGenre
    {
        [Key]
        [Column(Order = 1)]
        public Guid? BookId { get; set; }
        [ForeignKey("BookId")]
        public Book Book { get; set; }

        [Key]
        [Column(Order = 2)]
        public Guid? GenreId { get; set; }
        [ForeignKey("GenreId")]
        public Genre Genre { get; set; }
    }
}

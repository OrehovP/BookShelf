using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using DataLayer;

namespace LogicLayer.PresentationModel.Forms
{
    public class BookForm
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public DateTime PublicationDate { get; set; }

        public string Description { get; set; }

        public Guid AuthorId { get; set; }

        public IEnumerable<Guid?> GenreIds { get; set; }
    }

    public class HForm
    {
        public BookForm Form { get; set; }
    }
}

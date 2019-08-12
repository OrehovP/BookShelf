using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.PresentationModel
{
    public class PBook
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public DateTime PublicationDate { get; set; }

        public string Description { get; set; }

        public Guid AuthorId { get; set; }

        public string AuthorName { get; set; }
    }
}

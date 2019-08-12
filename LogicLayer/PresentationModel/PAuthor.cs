using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.PresentationModel
{
    public class PAuthor
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public DateTime DateBorn { get; set; }

        public bool CanDelete { get; set; }
    }
}

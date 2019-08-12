using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using DataLayer;

namespace LogicLayer.PresentationModel.Forms
{
    public  class AuthorForm
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public DateTime DateBorn { get; set; }
    }

    public class HAuthorForm
    {
        public AuthorForm Form { get; set; }
    }
}

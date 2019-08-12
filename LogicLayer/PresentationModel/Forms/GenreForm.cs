using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using DataLayer;

namespace LogicLayer.PresentationModel.Forms
{
    public  class GenreForm
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
    }

    public class HGenreForm
    {
        public GenreForm Form { get; set; }
    }
}

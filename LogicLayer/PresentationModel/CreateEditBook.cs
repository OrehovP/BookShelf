using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using LogicLayer.PresentationModel.Forms;

namespace LogicLayer.PresentationModel
{
    public class CreateEditBook
    {
        public BookForm Form { get; set; }

        public IEnumerable<SelectListItem> Authors { get; set; }

        public IEnumerable<PGenre> Genres { get; set; }
    }
}

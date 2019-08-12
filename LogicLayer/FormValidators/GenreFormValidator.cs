using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.WebPages;
using LogicLayer.Infrastructure;
using LogicLayer.PresentationModel;
using LogicLayer.PresentationModel.Forms;

namespace LogicLayer.FormValidators
{
    public class GenreFormValidator
    {
        public List<ValidatonException> Exceptions { get; set; }
        public GenreFormValidator()
        {
            Exceptions = new List<ValidatonException>();
        }

        public bool Validate(GenreForm form)
        {
            bool result = true;
            if (!string.IsNullOrWhiteSpace(form.Name))
            {
                if (form.Name.Length > 100)
                {
                    result = false;
                    Exceptions.Add(new ValidatonException("Длина имени превышает допустимое значение",""));
                }
            }
            else
            {
                result = false;
                Exceptions.Add(new ValidatonException("Имя пустое или состоит из пробельных символов", ""));
            }

            return result;
        }
    }
}

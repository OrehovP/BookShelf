using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.WebPages;
using LogicLayer.Infrastructure;
using LogicLayer.PresentationModel.Forms;

namespace LogicLayer.FormValidators
{
    public class BookFormValidator
    {
        public List<ValidatonException> Exceptions { get; set; }
        public BookFormValidator()
        {
            Exceptions = new List<ValidatonException>();
        }

        public bool Validate(BookForm form)
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

            if (!string.IsNullOrWhiteSpace(form.Description))
            {
                if (form.Description.Length > 1000)
                {
                    result = false;
                    Exceptions.Add(new ValidatonException("Длина описания превышает допустимое значение", ""));
                }
            }
            else
            {
                result = false;
                Exceptions.Add(new ValidatonException("Описание пустое или состоит из пробельных символов", ""));
            }

            return result;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicLayer.PresentationModel;
using LogicLayer.PresentationModel.Forms;

namespace LogicLayer.Interfaces
{
    public interface IAuthorService
    {
        IEnumerable<PAuthor> GetAuthors();
        CreateEditAuthor GetAuthor(Guid? id);
        void CreateEditAuthor(AuthorForm item);
        IEnumerable<PBook> GetBooks(Guid? authorId);
        void DeleteAuthor (Guid authorId);
    }
}

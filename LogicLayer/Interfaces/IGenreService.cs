using DataLayer;
using LogicLayer.PresentationModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicLayer.PresentationModel.Forms;

namespace LogicLayer.Interfaces
{
    public interface IGenreService
    { 
        IEnumerable<PGenre> GetGenres();
        void CreateEditGenre(GenreForm item);
        CreateEditGenre GetGenre(Guid? id);
        IEnumerable<PBook> GetBooks(Guid? genreId);
        void DeleteGenre(Guid genreId);
    }
}

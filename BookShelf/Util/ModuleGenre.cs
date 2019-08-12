using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LogicLayer.Interfaces;
using LogicLayer.Services;

namespace BookShelf.Util
{
    public class GenreModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IGenreService>().To<GenreService>();
        }
    }
}
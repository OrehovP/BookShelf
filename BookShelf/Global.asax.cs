using Ninject;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using BookShelf.Util;
using LogicLayer.Infrastructure;
using Ninject.Web.Mvc;

namespace BookShelf
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            NinjectModule authorModule = new AuthorModule();
            NinjectModule bookModule = new BookModule();
            NinjectModule genreModule = new GenreModule();
            NinjectModule serviceModule = new ServiceModule();
            var kernel = new StandardKernel(authorModule, bookModule, genreModule, serviceModule);
            DependencyResolver.SetResolver(new NinjectDependencyResolver(kernel));
        }
    }
}

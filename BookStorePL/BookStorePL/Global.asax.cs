using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Ninject;
using Ninject.Modules;
using BookStoreBLL.Dependencies;
using BookStorePL.Dependencies;
using Ninject.Web.Mvc;
using BookStoreBLL;

namespace BookStorePL
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            NinjectModule ninjectModule = new NinjectService("BookStoreDb");
            NinjectModule bookninjectmodule = new BookNinjectService();
            StandardKernel kernel = new StandardKernel(ninjectModule, bookninjectmodule);
            DependencyResolver.SetResolver(new NinjectDependencyResolver(kernel));
            App_Start.AutoMapperConfig.Initialize();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BookStoreBLL.Services;
using Ninject.Modules;

namespace BookStorePL.Dependencies
{
    public class BookNinjectService:NinjectModule
    {
        public override void Load()
        {
            Bind<IBookService>().To<BookService>();
        }
    }
}
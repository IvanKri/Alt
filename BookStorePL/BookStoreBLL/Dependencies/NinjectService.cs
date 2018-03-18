using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject.Modules;
using BookStoreDAL.Repositories;

namespace BookStoreBLL.Dependencies
{
    public class NinjectService:NinjectModule
    {
        string connectionstring;
        public NinjectService(string constring)
        {
            connectionstring = constring;
        }
        public override void Load()
        {
            Bind<IBookRepository>().To<BookRepository>().WithConstructorArgument(connectionstring);
        }
    }
}

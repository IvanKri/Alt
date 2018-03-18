using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using BookStoreBLL.BLData;
using BookStorePL.Models;

namespace BookStorePL.App_Start
{
    public class AutoMapperConfig
    {
        public static void Initialize()
        {
            Mapper.Initialize(x=> {

                x.CreateMap<BLBook, BookViewModel>();
            });

        }
    }
}
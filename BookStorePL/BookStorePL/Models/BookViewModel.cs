using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStorePL.Models
{
    public class BookViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public string Year { get; set; }
    }
}
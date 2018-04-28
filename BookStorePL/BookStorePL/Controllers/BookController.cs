using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookStoreBLL.Services;
using BookStoreBLL.BLData;
using BookStorePL.Models;
using AutoMapper;

namespace BookStorePL.Controllers
{
    public class BookController : Controller
    {
        IBookService ser;
        public BookController(IBookService service)
        {
            ser = service;
        }
        public ActionResult Index()
        {
            IEnumerable<BLBook> Blbooks = ser.GetAllBooks();
            IEnumerable<BookViewModel> books = Mapper.Map<IEnumerable<BLBook>, List<BookViewModel>>(Blbooks);
            return View(books);
        }
        public ActionResult AddBook()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddBook(BookViewModel book)
        {
            if (ModelState.IsValid)
            {
                if (book != null)
                {
                    BLBook blbook = Mapper.Map<BookViewModel, BLBook>(book);
                    ser.AddBook(blbook);
                }
                return Redirect("Index");
            }
            return View();
            
        }
        public ActionResult DeleteBook(int bookId)
        {
            if (bookId != 0)
            {
                ser.DeleteBook(bookId);
            }
            return Redirect("Index");

        }
        public ActionResult UpdateBook(int bookId)
        {
            if (bookId != 0)
            {
                BLBook blbook = ser.GetBookById(bookId);
                BookViewModel mbook = Mapper.Map<BLBook, BookViewModel>(blbook);
                return View(mbook);
            }
            return View();
        }
        [HttpPost]
        public ActionResult UpdateBook(BookViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (model != null)
                {
                    ser.UpdateBook(Mapper.Map<BookViewModel, BLBook>(model));
                }
                return Redirect("Index");
            }
            return View();
        }
    }
}
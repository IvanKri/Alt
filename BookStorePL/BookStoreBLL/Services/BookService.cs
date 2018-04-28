using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStoreBLL.BLData;
using BookStoreDAL.Repositories;
using BookStoreDAL.Data;
using AutoMapper;

namespace BookStoreBLL.Services
{
    public interface IBookService
    {
        IEnumerable<BLBook> GetAllBooks();
        BLBook GetBookById(int bookId);
        void AddBook(BLBook book);
        void DeleteBook(int bookId);
        void UpdateBook(BLBook book);
        void SaveChanges();
    }
    public class BookService:IBookService
    {
        IBookRepository db;
        public BookService(IBookRepository repo)
        {
            db = repo;
        }
        public IEnumerable<BLBook> GetAllBooks()
        {
            return Mapper.Map<IEnumerable<Book>,List<BLBook>>(db.GetAllBooks());
        }
        public BLBook GetBookById(int bookId)
        {
            BLBook book = new BLBook();
            if (bookId != 0)
            {
                book = Mapper.Map<Book,BLBook>(db.GetBookById(bookId));
            }
            return book;
        }
        public void AddBook(BLBook book)
        {
            if (book != null)
            {
                Book abook = Mapper.Map<BLBook, Book>(book);
                db.AddBook(abook);
            }
        }
        public void DeleteBook(int bookId)
        {
            if (bookId != 0)
            {
                db.DeleteBook(bookId);
            }
        }
        public void UpdateBook(BLBook book)
        {
            if (book!= null)
            {
              db.UpdateBook(Mapper.Map<BLBook,Book>(book));
            }
        }
        public void SaveChanges()
        {
            db.SaveChanges();
        }
    }
}

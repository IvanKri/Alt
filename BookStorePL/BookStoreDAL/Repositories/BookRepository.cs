using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStoreDAL.Data;

namespace BookStoreDAL.Repositories
{
    public class BookRepository:IBookRepository
    {
        BookContext db;
        public BookRepository(string connectionsring)
        {
            db = new BookContext(connectionsring);
        }
        public IEnumerable<Book> GetAllBooks()
        {
            return db.Books.AsEnumerable();
        }
        public Book GetBookById(int bookId)
        {
            Book book = new Book();
            if (bookId != 0)
            {
                book = db.Books.FirstOrDefault(x => x.Id == bookId);
            }
            return book;
        }
        public void AddBook(Book book)
        {
            if (book != null)
            {
                db.Books.Add(book);
                db.SaveChanges();
            }
            
        }
        public void DeleteBook(int bookId)
        {
            if (bookId != 0)
            {
                Book book = db.Books.FirstOrDefault(x => x.Id == bookId);
                db.Books.Remove(book);
                db.SaveChanges();
            }
        }
        public void UpdateBook(Book book)
        {
            Book entity = db.Books.Find(book.Id);
            if (entity != null)
            {
                entity.Name = book.Name;
                entity.Author = book.Author;
                entity.Year = book.Year;
                db.SaveChanges();
            }
        }
        public void SaveChanges()
        {
            db.SaveChanges();
        }
    }
}

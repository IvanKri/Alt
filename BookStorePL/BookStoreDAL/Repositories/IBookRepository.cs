using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStoreDAL.Data;

namespace BookStoreDAL.Repositories
{
    public interface IBookRepository
    {
        IEnumerable<Book> GetAllBooks();
        Book GetBookById(int bookId);
        void AddBook(Book book);
        void DeleteBook(int bookId);
        void UpdateBook(Book book);
        void SaveChanges();
    }
}

using System.Collections.Generic;
using Todo.Models;

namespace Todo.Data
{
    public interface IBookRepo
    {
        bool SaveChanges();
        IEnumerable<Book> GetAllBooks();
        Book GetBookById(int id);
        void CreateBook(Book book);
        void DeleteBook(Book book);
    }
}

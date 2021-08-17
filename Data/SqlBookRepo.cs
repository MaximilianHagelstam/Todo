using System;
using System.Collections.Generic;
using System.Linq;
using Todo.Data;
using Todo.Models;

namespace Todo.Data
{
    public class SqlBookRepo : IBookRepo
    {
        private readonly TodoContext _context;

        public SqlBookRepo(TodoContext context)
        {
            _context = context;
        }

        public void CreateBook(Book book)
        {
            if (book == null)
            {
                throw new ArgumentNullException(nameof(book));
            }

            _context.Books.Add(book);
        }

        public void DeleteBook(Book book)
        {
            if (book == null)
            {
                throw new ArgumentNullException(nameof(book));
            }

            _context.Books.Remove(book);
        }

        public IEnumerable<Book> GetAllBooks()
        {
            return _context.Books.ToList();
        }

        public Book GetBookById(int id)
        {
            return _context.Books.FirstOrDefault(p => p.Id == id);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges()) > 0;
        }
    }
}
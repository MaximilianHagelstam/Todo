using System;
using System.Collections.Generic;
using System.Linq;
using Todo.Data;
using Todo.Models;

namespace Todo.Data
{
    public class SqlTodoRepo : ITodoRepo
    {
        private readonly TodoContext _context;

        public SqlTodoRepo(TodoContext context)
        {
            _context = context;
        }

        public void CreateItem(Item item)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }

            _context.Items.Add(item);
        }

        public IEnumerable<Item> GetAllItems()
        {
            return _context.Items.ToList();
        }

        public Item GetItemById(int id)
        {
            return _context.Items.FirstOrDefault(p => p.Id == id);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges()) > 0;
        }

        public void UpdateItem(Item item)
        {
            // Nada
        }
    }
}
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
        public IEnumerable<Item> GetAllItems()
        {
            return _context.Items.ToList();
        }

        public Item GetItemById(int id)
        {
            return _context.Items.FirstOrDefault(p => p.Id == id);
        }
    }
}
using System.Collections.Generic;
using Todo.Models;

namespace Todo.Data
{
    public interface ITodoRepo
    {
        IEnumerable<Item> GetAllItems();
        Item GetItemById(int id);
    }
}

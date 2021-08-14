using System.Collections.Generic;
using Todo.Models;

namespace Todo.Data
{
    public interface ITodoRepo
    {
        bool SaveChanges();
        IEnumerable<Item> GetAllItems();
        Item GetItemById(int id);
        void CreateItem(Item item);
        void UpdateItem(Item item);
        void DeleteItem(Item item);
    }
}

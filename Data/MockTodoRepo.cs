using System.Collections.Generic;
using Todo.Models;

namespace Todo.Data
{
    public class MockTodoRepo : ITodoRepo
    {
        public IEnumerable<Item> GetAllItems()
        {
            var items = new List<Item>
            {
                new Item { Id = 0, Title = "Make bread", Description = "Deez" },
                new Item { Id = 1, Title = "Go to shops", Description = "Ligma" },
                new Item { Id = 2, Title = "Eat", Description = "Nuts" },
            };

            return items;
        }
        public Item GetItemById(int id)
        {
            return new Item { Id = 0, Title = "Make bread", Description = "Deez" };
        }
    }
}

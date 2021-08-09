using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Todo.Data;
using Todo.Models;

namespace Todo.Controllers
{

    [Route("api/items")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        private readonly ITodoRepo _repository;

        public ItemsController(ITodoRepo repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Item>> GetAllItems()
        {
            var todoItems = _repository.GetAllItems();

            return Ok(todoItems);
        }

        [HttpGet("{id}")]
        public ActionResult<Item> GetItemById(int id)
        {
            var todoItem = _repository.GetItemById(id);

            return Ok(todoItem);
        }
    }
}
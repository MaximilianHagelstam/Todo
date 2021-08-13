using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Todo.Data;
using Todo.Dtos;
using Todo.Models;

namespace Todo.Controllers
{

    [Route("api/items")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        private readonly ITodoRepo _repository;
        private readonly IMapper _mapper;

        public ItemsController(ITodoRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ItemReadDto>> GetAllItems()
        {
            var todoItems = _repository.GetAllItems();

            return Ok(_mapper.Map<IEnumerable<ItemReadDto>>(todoItems));
        }

        [HttpGet("{id}")]
        public ActionResult<ItemReadDto> GetItemById(int id)
        {
            var todoItem = _repository.GetItemById(id);

            if (todoItem != null)
            {
                return Ok(_mapper.Map<ItemReadDto>(todoItem));
            }

            return NotFound();

        }
    }
}
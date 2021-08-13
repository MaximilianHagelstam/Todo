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

        [HttpGet("{id}", Name = "GetItemById")]
        public ActionResult<ItemReadDto> GetItemById(int id)
        {
            var todoItem = _repository.GetItemById(id);

            if (todoItem != null)
            {
                return Ok(_mapper.Map<ItemReadDto>(todoItem));
            }

            return NotFound();

        }

        [HttpPost]
        public ActionResult<ItemReadDto> CreateItem(ItemCreateDto itemCreateDto)
        {
            var itemModel = _mapper.Map<Item>(itemCreateDto);
            _repository.CreateItem(itemModel);
            _repository.SaveChanges();

            var ItemReadDto = _mapper.Map<ItemReadDto>(itemModel);

            return CreatedAtRoute(nameof(GetItemById), new { Id = ItemReadDto.Id }, ItemReadDto);
        }
    }
}
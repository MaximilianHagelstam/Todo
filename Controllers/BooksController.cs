using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Todo.Data;
using Todo.Dtos;
using Todo.Models;

namespace Todo.Controllers
{

    [Route("api/books")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookRepo _repository;
        private readonly IMapper _mapper;

        public BooksController(IBookRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<BookReadDto>> GetAllBooks()
        {
            var books = _repository.GetAllBooks();

            return Ok(_mapper.Map<IEnumerable<BookReadDto>>(books));
        }

        [HttpGet("{id}", Name = "GetBookById")]
        public ActionResult<BookReadDto> GetBookById(int id)
        {
            var book = _repository.GetBookById(id);

            if (book != null)
            {
                return Ok(_mapper.Map<BookReadDto>(book));
            }

            return NotFound();

        }

        [HttpPost]
        public ActionResult<BookReadDto> CreateBook(BookCreateDto bookCreateDto)
        {
            var bookModel = _mapper.Map<Book>(bookCreateDto);
            _repository.CreateBook(bookModel);
            _repository.SaveChanges();

            var BookReadDto = _mapper.Map<BookReadDto>(bookModel);

            return CreatedAtRoute(nameof(GetBookById), new { Id = BookReadDto.Id }, BookReadDto);
        }

        [HttpDelete("{id}")]
        public ActionResult RemoveBook(int id)
        {
            var bookModelFromRepo = _repository.GetBookById(id);

            if (bookModelFromRepo == null)
            {
                return NotFound();
            }

            _repository.DeleteBook(bookModelFromRepo);

            _repository.SaveChanges();

            return NoContent();
        }
    }
}

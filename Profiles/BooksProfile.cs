using AutoMapper;
using Todo.Dtos;
using Todo.Models;

namespace Todo.Profiles
{
    public class BooksProfile : Profile
    {
        public BooksProfile()
        {
            CreateMap<Book, BookReadDto>();
            CreateMap<BookCreateDto, Book>();
        }
    }
}

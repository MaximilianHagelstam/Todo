using AutoMapper;
using Todo.Dtos;
using Todo.Models;

namespace Todo.Profiles
{
    public class ItemsProfile : Profile
    {
        public ItemsProfile()
        {
            CreateMap<Item, ItemReadDto>();
            CreateMap<ItemCreateDto, Item>();
            CreateMap<ItemUpdateDto, Item>();
            CreateMap<Item, ItemUpdateDto>();
        }
    }
}
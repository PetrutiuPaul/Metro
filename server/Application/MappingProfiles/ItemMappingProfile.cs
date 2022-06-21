using AutoMapper;
using Contracts.Models;
using Domain.Entities;

namespace Application.MappingProfiles
{
    public class ItemMappingProfile : Profile
    {
        public ItemMappingProfile()
        {
            CreateMap<Item, ItemDto>().ReverseMap();
        }
    }
}
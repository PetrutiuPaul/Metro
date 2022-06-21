using AutoMapper;
using Contracts.Models;
using Domain.Entities;

namespace Application.MappingProfiles
{
    public class BasketMappingProfile : Profile
    {
        public BasketMappingProfile()
        {
            CreateMap<Basket, BasketDto>()
                .ForMember(dest => dest.TotalNet, opt => opt.MapFrom(src => src.TotalNet))
                .ForMember(dest => dest.TotalGross, opt => opt.MapFrom(src => src.TotalGross))
                .ForMember(dest => dest.Items, opt => opt.MapFrom(src => src.Items))
                .ReverseMap();
        }
    }
}
using AutoMapper;
using SportsZoneWebAPI.DTOs;
using SportsZoneWebAPI.Models;
using System;

namespace SportsZoneWebAPI.Mappings.MappingProfiles
{
    public class CartMapping : Profile
    {
        public CartMapping()
        {
            CreateMap<Cart, CartResponseDTO>();
            CreateMap<CartRequestDTO, Cart>()
                .ForMember(dest => dest.UpdatedBy, opt => opt.MapFrom(src => src.CreatedUpdatedBy))
                .ForMember(dest => dest.UpdatedDate, opt => opt.MapFrom(src => DateTime.Now))
                .ForMember(dest => dest.CreatedBy, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedDate, opt => opt.Ignore());
        }
    }
}

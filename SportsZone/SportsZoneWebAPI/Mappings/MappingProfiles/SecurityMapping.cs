using AutoMapper;
using SportsZoneWebAPI.DTOs;
using SportsZoneWebAPI.Models;
using SportsZoneWebAPI.Repositories;
using System;

namespace SportsZoneWebAPI.Mappings.MappingProfiles
{
    public class SecurityMapping : Profile
    {
        public SecurityMapping()
        {
            CreateMap<Security, SecurityResponseDTO>();

            CreateMap<SecurityRequestDTO, Security>()
            .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
            .ForMember(dest => dest.SecurityQuestion, opt => opt.MapFrom(src => src.SecurityQuestion))
            .ForMember(dest => dest.Password, opt => opt.MapFrom(src => Util.HashItemToBytes(src.Password)))
            .ForMember(dest => dest.Answer, opt => opt.MapFrom(src => Util.HashItemToBytes(src.Answer)))
            .ForMember(dest => dest.UpdatedBy, opt => opt.MapFrom(src => src.CreatedUpdatedBy))
            .ForMember(dest => dest.UpdatedDate, opt => opt.MapFrom(src => DateTime.Now))
            .ForMember(dest => dest.CreatedBy, opt => opt.Ignore())
            .ForMember(dest => dest.CreatedDate, opt => opt.Ignore());

        }
        //here you can customize the dto/model request object to the model/dto response object
        //like clupping the two into one firstname+lastname = fullname
    }
}

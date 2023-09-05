using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using AutoMapper;
using SportsZoneWebAPI.Models;
using SportsZoneWebAPI.DTOs;
namespace SportsZoneWebAPI.Mappings
{
    public class SecurityMapping : Profile
    {
        public SecurityMapping()
        {
            CreateMap<Security, SecurityResponseDTO>();
            CreateMap<SecurityRequestDTO, Security>()
            .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
            .ForMember(dest => dest.SecurityQuestion, opt => opt.MapFrom(src => src.SecurityQuestion));
        }
        //here you can customize the dto/model request object to the model/dto response object
        //like clupping the two into one firstname+lastname = fullname
    }
}

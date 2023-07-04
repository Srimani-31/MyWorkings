using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RiddleWebAPI.Dtos;
using RiddleWebAPI.Models;

namespace RiddleWebAPI.Mappings
{
    public class UserProfile : Profile 
    {
        public UserProfile()
        {
            CreateMap<User, UserDto>().ReverseMap();
            
        }
    }
}

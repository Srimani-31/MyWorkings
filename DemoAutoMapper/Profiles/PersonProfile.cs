using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using AutoMapper;
using DemoAutoMapper.Dtos;
using DemoAutoMapper.Models;

namespace DemoAutoMapper.Profiles
{
    public class PersonProfile : Profile
    {
        public PersonProfile()
        {

            //Mapping properties from Person to PersonDto
            CreateMap<Person, PersonDto>();
            //ForMember is used incase if any field doesn't match
            //.ForMember(
            //destination => destination.FullName, 
            //opt => opt.MapFrom(source => source.FirstName+ " "+source.MiddleName+" "+source.LastName));
            CreateMap<PersonDto, Person>();
                //.ForMember(
                //destination => destination.FirstName,
                //opt => opt.MapFrom(source => source.FullName));

        }
    }
}

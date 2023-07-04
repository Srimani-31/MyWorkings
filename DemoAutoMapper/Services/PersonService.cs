using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DemoAutoMapper.Repositories;
using DemoAutoMapper.Models;
using DemoAutoMapper.Dtos;

namespace DemoAutoMapper.Services
{
    public class PersonService
    {
        private readonly IMapper _mapper;
        private readonly PersonRepository _personRepository;
        public PersonService(IMapper mapper, PersonRepository personRepository)
        {
            _personRepository = personRepository;
            _mapper = mapper;
        }
        public void AddPerson(PersonDto personDto)
        {
            var person = _mapper.Map<Person>(personDto);
            _personRepository.AddPerson(person);
        }

        public List<PersonDto> GetAllPersons()
        {
            var persons = _personRepository.GetAllPersons();
            var personsDto = _mapper.Map<List<PersonDto>>(persons);
            return personsDto;

        }
        public PersonDto GetPersonById(int Id)
        {
            var person = _personRepository.GetPersonById(Id);
            var personDto = _mapper.Map<PersonDto>(person);
            return personDto;
        }
       
    }
}

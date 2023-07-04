using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DemoAutoMapper.Services;
using DemoAutoMapper.Dtos;
namespace DemoAutoMapper.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DemoAutoMapperController : ControllerBase
    {
        private readonly PersonService _personService;
        public DemoAutoMapperController(PersonService personService)
        {
            _personService = personService;
        }
        [HttpGet("GetAllUsers")]
        public IActionResult GetAllPersons()
        {
            var persons = _personService.GetAllPersons();
            return StatusCode(200,persons);
        }
        [HttpGet("GetUserById/{Id}")]
        public IActionResult GetPersonById(int Id)
        {
            var person = _personService.GetPersonById(Id);
            return StatusCode(200, person);
        }
        [HttpPost]
        public IActionResult AddPerson(PersonDto personDto)
        {
            _personService.AddPerson(personDto);
            return StatusCode(200, personDto);
        }
    }
}

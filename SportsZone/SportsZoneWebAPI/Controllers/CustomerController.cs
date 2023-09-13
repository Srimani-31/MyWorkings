using Microsoft.AspNetCore.Mvc;
using SportsZoneWebAPI.DTOs;
using SportsZoneWebAPI.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SportsZoneWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet, Route("GetAllCustomers")]
        public async Task<ActionResult<IEnumerable<CustomerResponseDTO>>> GetAllCustomers()
        {
            try
            {
                IEnumerable<CustomerResponseDTO> customerResponseDTOs = await _customerService.GetAllCustomers();
                return Ok(customerResponseDTOs);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpGet, Route("GetCustomerByCustomerID/{email}")]
        public async Task<ActionResult<CustomerResponseDTO>> GetCustomerByCustomerID(string email)
        {
            try
            {
                CustomerResponseDTO customerResponseDTO = await _customerService.GetCustomerByCustomerID(email);
                return Ok(customerResponseDTO);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost, Route("CreateCustomer")]
        public async Task<ActionResult<CustomerRequestDTO>> CreateCustomer([FromBody] CustomerRequestDTO customerRequestDTO)
        {
            try
            {
                await _customerService.CreateCustomer(customerRequestDTO);
                return Ok(customerRequestDTO);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut, Route("UpdateCustomer")]
        public async Task<ActionResult<CustomerRequestDTO>> UpdateCustomer([FromBody] CustomerRequestDTO customerRequestDTO)
        {
            try
            {
                await _customerService.UpdateCustomer(customerRequestDTO);
                return Ok(customerRequestDTO);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpDelete, Route("DeleteAllCustomers")]
        public async Task<ActionResult> DeleteAllCustomers()
        {
            try
            {
                await _customerService.DeleteAllCustomers();
                return Ok("All Customers deleted succesfully");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete, Route("DeleteCustomerByCustomerID/{email}")]
        public async Task<ActionResult> DeleteCustomerByCustomerID(string email)
        {
            try
            {
                await _customerService.DeleteCustomerByCustomerID(email);
                return Ok($"Customer with ID : {email} deleted succesfully");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }
}

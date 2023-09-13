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
                return StatusCode(500, e.Message);
            }
        }
        [HttpGet, Route("GetCustomerByCustomerID/{email}")]
        public async Task<ActionResult<CustomerResponseDTO>> GetCustomerByCustomerID(string email)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(email))
                {
                    // Invalid input: Return a BadRequest response with an error message
                    return BadRequest();
                }
                if (!await _customerService.IsAvail(email))
                {
                    return NotFound();
                }
                CustomerResponseDTO customerResponseDTO = await _customerService.GetCustomerByCustomerID(email);
                return Ok(customerResponseDTO);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPost, Route("CreateCustomer")]
        public async Task<ActionResult<CustomerRequestDTO>> CreateCustomer([FromBody] CustomerRequestDTO customerRequestDTO)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    // Model validation failed: Return a BadRequest response with validation errors
                    return BadRequest(ModelState);
                }
                if (await _customerService.IsAvail(customerRequestDTO.Email))
                {
                    return Conflict();
                }
                await _customerService.CreateCustomer(customerRequestDTO);
                return Ok(customerRequestDTO);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPut, Route("UpdateCustomer")]
        public async Task<ActionResult<CustomerRequestDTO>> UpdateCustomer([FromBody] CustomerRequestDTO customerRequestDTO)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    // Model validation failed: Return a BadRequest response with validation errors
                    return BadRequest(ModelState);
                }
                if (!await _customerService.IsAvail(customerRequestDTO.Email))
                {
                    return NotFound();
                }
                await _customerService.UpdateCustomer(customerRequestDTO);
                return Ok(customerRequestDTO);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }


        [HttpDelete, Route("DeleteCustomerByCustomerID/{email}")]
        public async Task<ActionResult> DeleteCustomerByCustomerID(string email)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(email))
                {
                    // Invalid input: Return a BadRequest response with an error message
                    return BadRequest("Input parameter 'email' is required and cannot be empty.");
                }
                if (!await _customerService.IsAvail(email))
                {
                    return NotFound();
                }
                await _customerService.DeleteCustomerByCustomerID(email);
                return Ok($"Customer with ID : {email} deleted succesfully");
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        #region Rare use case
        //[HttpDelete, Route("DeleteAllCustomers")]
        //public async Task<ActionResult> DeleteAllCustomers()
        //{
        //    try
        //    {
        //        await _customerService.DeleteAllCustomers();
        //        return Ok("All Customers deleted succesfully");
        //    }
        //    catch (Exception e)
        //    {
        //        return StatusCode(500, e.Message);
        //    }
        //} 
        #endregion
    }
}

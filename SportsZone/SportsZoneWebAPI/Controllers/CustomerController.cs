using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using SportsZoneWebAPI.Repositories;
using SportsZoneWebAPI.Models;

namespace SportsZoneWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly CustomerRepository _customerRepository;
        public CustomerController(CustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        [HttpGet, Route("GetAllCustomers")]
        public async Task<ActionResult<IEnumerable<Customer>>> GetAllCustomer()
        {
            try
            {
                IEnumerable<Customer> customers = await _customerRepository.GetAllCustomers();
                return Ok(customers);
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpGet, Route("GetCustomerByCustomerID/{email}")]
        public async Task<ActionResult<Customer>> GetCustomerByCustomerID(string email)
        {
            try
            {
                Customer customer = await _customerRepository.GetCustomerByCustomerID(email);
                return Ok(customer);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost,Route("CreateCustomer")]
        public async Task<ActionResult<Customer>> CreateCustomer([FromBody]Customer customer)
        {
            try
            {
                await _customerRepository.CreateCustomer(customer);
                return Ok(customer);
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut, Route("UpdateCustomer")]
        public async Task<ActionResult<Customer>> UpdateCustomer([FromBody] Customer customer)
        {
            try
            {
                await _customerRepository.UpdateCustomer(customer);
                return Ok(customer);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpDelete,Route("DeleteAllCustomers")]
        public async Task<ActionResult> DeleteAllCustomers()
        {
            try
            {
                await _customerRepository.DeleteAllCustomers();
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
                await _customerRepository.DeleteCustomerByCustomerID(email);
                return Ok($"Customer with ID : {email} deleted succesfully");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }
}

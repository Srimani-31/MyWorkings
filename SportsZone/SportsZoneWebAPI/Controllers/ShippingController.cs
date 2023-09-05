using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using SportsZoneWebAPI.Repositories;
using SportsZoneWebAPI.Models;
using SportsZoneWebAPI.DTOs;

namespace SportsZoneWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShippingController : ControllerBase
    {
        private readonly ShippingRepository _shippingRepository;
        public ShippingController(ShippingRepository shippingRepository)
        {
            _shippingRepository = shippingRepository;
        }

        [HttpGet, Route("GetAllShippingAddressesByCustomerID/{email}")]
        public async Task<ActionResult<IEnumerable<Shipping>>> GetAllShippingAddressesByCustomerID(string email)
        {
            try
            {
                IEnumerable<Shipping> shippings = await _shippingRepository.GetAllShippingAddressesByCustomerID(email);
                return Ok(shippings);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpGet, Route("GetShippingAddressByShippingID/{shippingID}")]
        public async Task<ActionResult<Shipping>> GetShippingAddressByShippingID(int shippingID)
        {
            try
            {
                Shipping shipping = await _shippingRepository.GetShippingAddressByShippingID(shippingID);
                return Ok(shipping);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost, Route("AddNewShippingAddress")]
        public async Task<ActionResult<Shipping>> AddNewShippingAddress([FromBody] Shipping shipping)
        {
            try
            {
                await _shippingRepository.AddNewShippingAddress(shipping);
                return Ok(shipping);
            }
            catch (Exception e)
            {
                return BadRequest(e.InnerException);
            }
        }

        [HttpPut, Route("UpdateShippingAddress")]
        public async Task<ActionResult<Shipping>> UpdateShippingAddress([FromBody] Shipping shipping)
        {
            try
            {
                await _shippingRepository.UpdateShippingAddress(shipping);
                return Ok(shipping);
            }
            catch (Exception e)
            {
                return BadRequest(e.InnerException);
            }
        }

        [HttpDelete, Route("DeleteShippingAddressByShippingID/{shippingID}")]
        public async Task<ActionResult> DeleteShippingAddressByShippingID(int shippingID)
        {
            try
            {
                await _shippingRepository.DeleteShippingAddressByShippingID(shippingID);
                return Ok($"Shipping address with ID : {shippingID} deleted succesfully");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}

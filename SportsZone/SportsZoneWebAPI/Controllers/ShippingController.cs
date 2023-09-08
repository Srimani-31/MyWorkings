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
    public class ShippingController : ControllerBase
    {
        private readonly IShippingService _shippingService;
        public ShippingController(IShippingService shippingService)
        {
            _shippingService = shippingService;
        }
        [HttpGet, Route("GetAllShippingAddresses")]
        public async Task<ActionResult<IEnumerable<ShippingResponseDTO>>> GetAllShippingAddresses()
        {
            try
            {
                IEnumerable<ShippingResponseDTO> shippingResponseDTOs = await _shippingService.GetAllShippingAddresses();
                return Ok(shippingResponseDTOs);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpGet, Route("GetAllShippingAddressesByCustomerID/{email}")]
        public async Task<ActionResult<IEnumerable<ShippingResponseDTO>>> GetAllShippingAddressesByCustomerID(string email)
        {
            try
            {
                IEnumerable<ShippingResponseDTO> shippingResponseDTOs = await _shippingService.GetAllShippingAddressesByCustomerID(email);
                return Ok(shippingResponseDTOs);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpGet, Route("GetShippingAddressByShippingID/{shippingID}")]
        public async Task<ActionResult<ShippingResponseDTO>> GetShippingAddressByShippingID(int shippingID)
        {
            try
            {
                ShippingResponseDTO shippingResponseDTO = await _shippingService.GetShippingAddressByShippingID(shippingID);
                return Ok(shippingResponseDTO);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost, Route("AddNewShippingAddress")]
        public async Task<ActionResult<ShippingRequestDTO>> AddNewShippingAddress([FromBody] ShippingRequestDTO shippingRequestDTO)
        {
            try
            {
                await _shippingService.AddNewShippingAddress(shippingRequestDTO);
                return Ok(shippingRequestDTO);
            }
            catch (Exception e)
            {
                return BadRequest(e.InnerException);
            }
        }

        [HttpPut, Route("UpdateShippingAddress")]
        public async Task<ActionResult<ShippingRequestDTO>> UpdateShippingAddress([FromBody] ShippingRequestDTO shippingRequestDTO)
        {
            try
            {
                await _shippingService.UpdateShippingAddress(shippingRequestDTO);
                return Ok(shippingRequestDTO);
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
                await _shippingService.DeleteShippingAddressByShippingID(shippingID);
                return Ok($"Shipping address with ID : {shippingID} deleted succesfully");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}

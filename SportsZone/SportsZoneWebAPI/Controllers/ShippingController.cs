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
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet, Route("GetAllShippingAddressesByCustomerID/{email}")]
        public async Task<ActionResult<IEnumerable<ShippingResponseDTO>>> GetAllShippingAddressesByCustomerID(string email)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(email))
                {
                    return BadRequest();
                }
                IEnumerable<ShippingResponseDTO> shippingResponseDTOs = await _shippingService.GetAllShippingAddressesByCustomerID(email);
                return Ok(shippingResponseDTOs);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet, Route("GetShippingAddressByShippingID/{shippingID}")]
        public async Task<ActionResult<ShippingResponseDTO>> GetShippingAddressByShippingID(int shippingID)
        {
            try
            {
                if (shippingID == 0)
                {
                    return BadRequest();
                }
                if (!await _shippingService.IsAvail(shippingID))
                {
                    return NotFound();
                }
                ShippingResponseDTO shippingResponseDTO = await _shippingService.GetShippingAddressByShippingID(shippingID);
                return Ok(shippingResponseDTO);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPost, Route("AddNewShippingAddress")]
        public async Task<ActionResult<ShippingRequestDTO>> AddNewShippingAddress([FromBody] ShippingRequestDTO shippingRequestDTO)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                if (await _shippingService.IsAvail(shippingRequestDTO.ShippingID))
                {
                    return Conflict();
                }
                await _shippingService.AddNewShippingAddress(shippingRequestDTO);
                return Ok(shippingRequestDTO);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPut, Route("UpdateShippingAddress")]
        public async Task<ActionResult<ShippingRequestDTO>> UpdateShippingAddress([FromBody] ShippingRequestDTO shippingRequestDTO)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                if (!await _shippingService.IsAvail(shippingRequestDTO.ShippingID))
                {
                    return NotFound();
                }
                await _shippingService.UpdateShippingAddress(shippingRequestDTO);
                return Ok(shippingRequestDTO);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpDelete, Route("DeleteShippingAddressByShippingID/{shippingID}")]
        public async Task<ActionResult> DeleteShippingAddressByShippingID(int shippingID)
        {
            try
            {
                if (shippingID == 0)
                {
                    return BadRequest("Input parameter 'shippingID' is required and cannot be empty.");
                }
                if (!await _shippingService.IsAvail(shippingID))
                {
                    return NotFound();
                }
                await _shippingService.DeleteShippingAddressByShippingID(shippingID);
                return Ok($"Shipping address with ID : {shippingID} deleted succesfully");
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}

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
    public class SecurityController : ControllerBase
    {
        private readonly ISecurityService _securityService;
        public SecurityController(ISecurityService securityService)
        {
            _securityService = securityService;
        }

        [HttpGet, Route("GetAllSecurityDetails")]
        public async Task<ActionResult<IEnumerable<SecurityResponseDTO>>> GetAllSecurityDetails()
        {
            try
            {
                IEnumerable<SecurityResponseDTO> securityResponseDTOs = await _securityService.GetAllSecurityDetails();
                return Ok(securityResponseDTOs);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet, Route("GetSecurityDetails/{email}")]
        public async Task<ActionResult<SecurityResponseDTO>> GetSecurityDetailsByCustomerID(string email)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(email))
                {
                    return BadRequest();
                }
                if (!await _securityService.IsAvail(email))
                {
                    return NotFound();
                }
                SecurityResponseDTO securityResponseDto = await _securityService.GetSecurityDetailsByCustomerID(email);
                return Ok(securityResponseDto);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPost, Route("AddSecurityDetails")]
        public async Task<ActionResult<SecurityRequestDTO>> AddSecurityDetails([FromBody] SecurityRequestDTO securityRequestDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                if (await _securityService.IsAvail(securityRequestDto.Email))
                {
                    return Conflict();
                }
                await _securityService.AddSecurityDetails(securityRequestDto);
                return Ok(securityRequestDto);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPut, Route("UpdateSecurityDetails")]
        public async Task<ActionResult<SecurityRequestDTO>> UpdateSecurityDetails([FromBody] SecurityRequestDTO securityRequestDTO)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                if (!await _securityService.IsAvail(securityRequestDTO.Email))
                {
                    return NotFound();
                }
                await _securityService.UpdateSecurityDetails(securityRequestDTO);
                return Ok(securityRequestDTO);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpDelete, Route("DeleteSecurityDetails/{email}")]
        public async Task<ActionResult> DeleteSecurityDetailsByCustomerID(string email)
        {
            try
            {
                if (string.IsNullOrEmpty(email))
                {
                    return BadRequest("Input parameter 'email' is required and cannot be empty.");
                }
                if (!await _securityService.IsAvail(email))
                {
                    return NotFound();
                }
                await _securityService.DeleteSecurityDetailsByCustomerID(email);
                return Ok($"Security details with ID : {email} deleted succesfully");
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}

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
    public class SecurityController : ControllerBase
    {
        private readonly SecurityRepository _securityRepository;
        public SecurityController(SecurityRepository securityRepository)
        {
            _securityRepository = securityRepository;
        }

        [HttpGet, Route("GetSecurityDetails/{email}")]
        public async Task<ActionResult<SecurityResponseDTO>> GetSecurityDetailsByCustomerID(string email)
        {
            try
            {
                SecurityResponseDTO securityResponseDto = await _securityRepository.GetSecurityDetailsByCustomerID(email);
                return Ok(securityResponseDto);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost, Route("AddSecurityDetails")]
        public async Task<ActionResult<SecurityRequestDTO>> AddSecurityDetails([FromBody] SecurityRequestDTO securityRequestDto)
        {
            try
            {
                await _securityRepository.AddSecurityDetails(securityRequestDto);
                return Ok(securityRequestDto);
            }
            catch (Exception e)
            {
                return BadRequest(e.InnerException);
            }
        }

        [HttpPut, Route("UpdateSecurityDetails")]
        public async Task<ActionResult<Security>> UpdateCustomer([FromBody] Security security)
        {
            try
            {
                await _securityRepository.UpdateSecurityDetails(security);
                return Ok(security);
            }
            catch (Exception e)
            {
                return BadRequest(e.InnerException);
            }
        }

        [HttpDelete, Route("DeleteSecurityDetails/{email}")]
        public async Task<ActionResult> DeleteSecurityDetailsByCustomerID(string email)
        {
            try
            {
                await _securityRepository.DeleteSecurityDetailsByCustomerID(email);
                return Ok($"Security details with ID : {email} deleted succesfully");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}

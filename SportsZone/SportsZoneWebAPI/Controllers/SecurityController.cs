﻿using Microsoft.AspNetCore.Mvc;
using SportsZoneWebAPI.DTOs;
using SportsZoneWebAPI.Services.Interfaces;
using System;
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

        [HttpGet, Route("GetSecurityDetails/{email}")]
        public async Task<ActionResult<SecurityResponseDTO>> GetSecurityDetailsByCustomerID(string email)
        {
            try
            {
                SecurityResponseDTO securityResponseDto = await _securityService.GetSecurityDetailsByCustomerID(email);
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
                await _securityService.AddSecurityDetails(securityRequestDto);
                return Ok(securityRequestDto);
            }
            catch (Exception e)
            {
                return BadRequest(e.InnerException);
            }
        }

        [HttpPut, Route("UpdateSecurityDetails")]
        public async Task<ActionResult<SecurityRequestDTO>> UpdateSecurityDetails([FromBody] SecurityRequestDTO securityRequestDTO)
        {
            try
            {
                await _securityService.UpdateSecurityDetails(securityRequestDTO);
                return Ok(securityRequestDTO);
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
                await _securityService.DeleteSecurityDetailsByCustomerID(email);
                return Ok($"Security details with ID : {email} deleted succesfully");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
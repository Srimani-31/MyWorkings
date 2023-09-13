using Microsoft.AspNetCore.Mvc;
using SportsZoneWebAPI.DTOs;
using SportsZoneWebAPI.Services.Interfaces;
using System;
using System.Threading.Tasks;

namespace SportsZoneWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost, Route("Login")]
        public async Task<ActionResult> Login([FromBody] LoginDTO loginDTO)
        {
            try
            {
                if (await _authService.IsAuthenticatedUser(loginDTO.Email, loginDTO.Password))
                {
                    var token = await _authService.GenerateJwtToken(loginDTO);
                    return Ok(token);
                }
                else
                {
                    return Unauthorized();
                }
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SportsZoneWebAPI.DTOs;
using SportsZoneWebAPI.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using SportsZoneWebAPI.Repositories;

namespace SportsZoneWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        private readonly ISecurityService _securityService;
        public IConfiguration _configuration;

        public AuthController(ICustomerService customerService, ISecurityService securityService, IConfiguration configuration)
        {
            _customerService = customerService;
            _securityService = securityService;
            _configuration = configuration;
        }

        [HttpPost]
        public async Task<ActionResult> Login([FromBody] LoginDTO loginDTO)
        {
            try
            {
                if (await IsValidEmail(loginDTO.Email) && await IsValidPassword(loginDTO.Password))
                {
                    var token = GenerateJwtToken(loginDTO);
                    return Ok(token);
                }
                else
                {
                    return Unauthorized();
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        private string GenerateJwtToken(LoginDTO loginDTO)
        {
            try
            {
                var jwt = _configuration.GetSection("Jwt").Get<Jwt>();

                var claims = new[]
                {
                new Claim(JwtRegisteredClaimNames.Sub,jwt.Subject),
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat,DateTime.UtcNow.ToString()),
                new Claim("Email",loginDTO.Email),
                new Claim("Password",loginDTO.Password)
            };
                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwt.key));
                var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken
                (
                    jwt.Issuer,
                    jwt.Audience,
                    claims,
                    expires: DateTime.Now.AddMinutes(10),
                    signingCredentials: signIn
                );
                string tokenhandler = new JwtSecurityTokenHandler().WriteToken(token);
                return tokenhandler;
            }
            catch (Exception)
            {
                throw;
            }

        }
        private async Task<bool> IsValidEmail(string email)
        {
            IEnumerable<CustomerResponseDTO> customerResponseDTOs = await _customerService.GetAllCustomers();
            foreach (CustomerResponseDTO customerResponseDTO in customerResponseDTOs)
            {
                if (customerResponseDTO.Email == email)
                    return true;
            }
            return false;
        }
        private async Task<bool> IsValidPassword(string password)
        {
            IEnumerable<SecurityResponseDTO> securityResponseDTOs = await _securityService.GetAllSecurityDetails();
            foreach (SecurityResponseDTO securityResponseDTO in securityResponseDTOs)
            {
                if (Util.VerifyPassword(securityResponseDTO.Password, password)) ;
                    return true;
            }
            return false;
        }
       

    }
}

using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SportsZoneWebAPI.DTOs;
using SportsZoneWebAPI.Models;
using SportsZoneWebAPI.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
namespace SportsZoneWebAPI.Repositories
{
    public class AuthRepository : IAuthRepository
    {
        public IConfiguration _configuration;
        public readonly ICustomerRespository _customerRepository;
        public readonly ISecurityRepository _securityRepository;
        public AuthRepository(IConfiguration configuration, ICustomerRespository customerRepository, ISecurityRepository securityRepository)
        {
            _configuration = configuration;
            _customerRepository = customerRepository;
            _securityRepository = securityRepository;
        }

        public async Task<string> GenerateJwtToken(LoginDTO loginDTO)
        {
            try
            {
                Customer customer = await _customerRepository.GetCustomerByCustomerID(loginDTO.Email);
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
        public async Task<bool> IsValidEmail(string email)
        {
            IEnumerable<Customer> customers = await _customerRepository.GetAllCustomers();
            foreach (Customer customer in customers)
            {
                if (customer.Email == email)
                    return true;
            }
            return false;
        }
        public async Task<bool> IsValidPassword(string password)
        {
            IEnumerable<Security> securities = await _securityRepository.GetAllSecurityDetails();
            foreach (Security security in securities)
            {
                if (Util.VerifyPassword(security.Password, password))
                    return true;
            }
            return false;
        }
    }
}

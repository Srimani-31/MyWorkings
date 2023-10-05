using SportsZoneWebAPI.DTOs;
using SportsZoneWebAPI.Repositories.Interfaces;
using SportsZoneWebAPI.Services.Interfaces;
using System;
using System.Threading.Tasks;

namespace SportsZoneWebAPI.Services
{
    public class AuthService : IAuthService
    {
        private readonly IAuthRepository _authRepository;

        public AuthService(IAuthRepository authRepository)
        {
            _authRepository = authRepository;
        }

        public async Task<bool> IsAuthenticatedUser(string email, string password)
        {
            try
            {
                return await _authRepository.IsValidEmail(email) && await _authRepository.IsValidPassword(password);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<string> GenerateJwtToken(LoginDTO loginDTO)
        {
            try
            {
                return await _authRepository.GenerateJwtToken(loginDTO);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}

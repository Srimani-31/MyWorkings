﻿using SportsZoneWebAPI.DTOs;
using System.Threading.Tasks;

namespace SportsZoneWebAPI.Repositories.Interfaces
{
    public interface IAuthRepository
    {
        public Task<bool> IsValidPassword(string password);
        public Task<bool> IsValidEmail(string email);
        public Task<string> GenerateJwtToken(LoginDTO loginDTO);
    }
}

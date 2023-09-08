using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SportsZoneWebAPI.DTOs;
namespace SportsZoneWebAPI.Services.Interfaces
{
    public interface ISecurityService
    {
        public Task<SecurityResponseDTO> GetSecurityDetailsByCustomerID(string email);
        public Task AddSecurityDetails(SecurityRequestDTO securityRequestDTO);
        public Task UpdateSecurityDetails(SecurityRequestDTO securityRequestDTO);
        public Task DeleteSecurityDetailsByCustomerID(string email);
    }
}

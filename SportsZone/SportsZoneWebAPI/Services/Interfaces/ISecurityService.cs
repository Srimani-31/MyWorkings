using SportsZoneWebAPI.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SportsZoneWebAPI.Services.Interfaces
{
    public interface ISecurityService
    {
        public Task<bool> IsAvail(string email);
        public Task<IEnumerable<SecurityResponseDTO>> GetAllSecurityDetails();
        public Task<SecurityResponseDTO> GetSecurityDetailsByCustomerID(string email);
        public Task AddSecurityDetails(SecurityRequestDTO securityRequestDTO);
        public Task UpdateSecurityDetails(SecurityRequestDTO securityRequestDTO);
        public Task DeleteSecurityDetailsByCustomerID(string email);
    }
}

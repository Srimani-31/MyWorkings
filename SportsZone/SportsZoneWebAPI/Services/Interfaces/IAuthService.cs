using SportsZoneWebAPI.DTOs;
using System.Threading.Tasks;

namespace SportsZoneWebAPI.Services.Interfaces
{
    public interface IAuthService
    {
        public Task<bool> IsAuthenticatedUser(string email,string password);
        public Task<string> GenerateJwtToken(LoginDTO loginDTO);
    }
}

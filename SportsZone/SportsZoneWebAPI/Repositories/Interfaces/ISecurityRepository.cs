using SportsZoneWebAPI.Models;
using System.Threading.Tasks;

namespace SportsZoneWebAPI.Repositories.Interfaces
{
    public interface ISecurityRepository
    {
        public Task<Security> GetSecurityDetailsByCustomerID(string email);
        public Task AddSecurityDetails(Security security);
        public Task UpdateSecurityDetails(Security security);
        public Task DeleteSecurityDetailsByCustomerID(string email);
    }
}

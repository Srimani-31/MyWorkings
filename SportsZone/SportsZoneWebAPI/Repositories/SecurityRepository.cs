using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using SportsZoneWebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace SportsZoneWebAPI.Repositories
{
    public class SecurityRepository
    {
        private readonly SportsZoneDbContext _sportsZoneDbContext;

        public SecurityRepository(SportsZoneDbContext sportsZoneDbContext)
        {
            _sportsZoneDbContext = sportsZoneDbContext;
        }

        public async Task<Security> GetSecurityDetailsByCustomerID(string email)
        {
            try
            {
                return await _sportsZoneDbContext.Securities.FindAsync(email);
            }
            catch(Exception)
            {
                throw;
            }
        }

        public async Task AddSecurityDetails(Security security)
        {
            try
            {
                _sportsZoneDbContext.Securities.Add(security);
                await _sportsZoneDbContext.SaveChangesAsync();
            }
            catch(Exception)
            {
                throw;
            }
        }
        public async Task UpdateSecurityDetails(Security security)
        {
            try
            {
                _sportsZoneDbContext.Securities.Update(security);
                await _sportsZoneDbContext.SaveChangesAsync();
            }
            catch(Exception)
            {
                throw;
            }
        }

        public async Task DeleteSecurityDetailsByCustomerID(string email)
        {
            try
            {
                Security security = _sportsZoneDbContext.Securities.SingleOrDefault(security => security.Email == email);
                if(security != null)
                {
                    _sportsZoneDbContext.Securities.Remove(security);
                    await _sportsZoneDbContext.SaveChangesAsync();
                }
                else
                {
                    throw new KeyNotFoundException("customer not found");
                }
            }
            catch(Exception)
            {
                throw;
            }
        }
    }
}

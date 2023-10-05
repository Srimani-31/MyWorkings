using Microsoft.EntityFrameworkCore;
using SportsZoneWebAPI.Data.Interfaces;
using SportsZoneWebAPI.Models;
using SportsZoneWebAPI.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsZoneWebAPI.Repositories
{
    public class SecurityRepository : ISecurityRepository
    {
        private readonly ISportsZoneDbContext _sportsZoneDbContext;
        private readonly IUtil _util;
        public SecurityRepository(ISportsZoneDbContext sportsZoneDbContext, IUtil util)
        {
            _sportsZoneDbContext = sportsZoneDbContext;
            _util = util;
        }
        public async Task<bool> IsAvail(string email)
        {
            try
            {
                return await _util.IsAvail(dbSet: _sportsZoneDbContext.Securities, stringID: email);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<IEnumerable<Security>> GetAllSecurityDetails()
        {
            try
            {
                return await _sportsZoneDbContext.Securities.ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<Security> GetSecurityDetailsByCustomerID(string email)
        {
            try
            {
                Security security = await _sportsZoneDbContext.Securities.FindAsync(email);
                return security;
            }
            catch (Exception)
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
            catch (Exception)
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
            catch (Exception)
            {
                throw;
            }
        }

        public async Task DeleteSecurityDetailsByCustomerID(string email)
        {
            try
            {
                Security security = _sportsZoneDbContext.Securities.SingleOrDefault(security => security.Email == email);
                if (security != null)
                {
                    _sportsZoneDbContext.Securities.Remove(security);
                    await _sportsZoneDbContext.SaveChangesAsync();
                }
                else
                {
                    throw new KeyNotFoundException("customer not found");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}

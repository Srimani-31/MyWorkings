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
    public class ShippingRepository : IShippingRepository
    {
        private readonly ISportsZoneDbContext _sportsZoneDbContext;
        public ShippingRepository(ISportsZoneDbContext sportsZoneDbContext)
        {
            _sportsZoneDbContext = sportsZoneDbContext;
        }

        public async Task<IEnumerable<Shipping>> GetAllShippingAddresses()
        {
            try
            {
                return await _sportsZoneDbContext.Shippings.ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<IEnumerable<Shipping>> GetAllShippingAddressesByCustomerID(string email)
        {
            try
            {
                IEnumerable<Shipping> shippings = await _sportsZoneDbContext.Shippings
                    .Where(Shipping => Shipping.BelongsTo == email)
                    .ToListAsync();
                return shippings;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<Shipping> GetShippingAddressByShippingID(int shippingID)
        {
            try
            {
                return await _sportsZoneDbContext.Shippings.FindAsync(shippingID);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task AddNewShippingAddress(Shipping shipping)
        {
            try
            {
                _sportsZoneDbContext.Shippings.Add(shipping);
                await _sportsZoneDbContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task UpdateShippingAddress(Shipping shipping)
        {
            try
            {
                _sportsZoneDbContext.Shippings.Update(shipping);
                await _sportsZoneDbContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task DeleteShippingAddressByShippingID(int shippingID)
        {
            try
            {
                Shipping shipping = await _sportsZoneDbContext.Shippings.SingleOrDefaultAsync(shipping => shipping.ShippingID == shippingID);

                if (shipping != null)
                {
                    _sportsZoneDbContext.Shippings.Remove(shipping);
                    await _sportsZoneDbContext.SaveChangesAsync();
                }
                else
                {
                    throw new KeyNotFoundException("Shipping address not found");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task DeleteAllShippingAddresses()
        {
            try
            {
                IEnumerable<Shipping> shippings = await GetAllShippingAddresses();

                foreach (Shipping shipping in shippings)
                {
                    _sportsZoneDbContext.Shippings.Remove(shipping);
                }
                await _sportsZoneDbContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task DeleteAllShippingAddressesByCustomerID(string email)
        {
            try
            {
                IEnumerable<Shipping> shippings = await GetAllShippingAddressesByCustomerID(email);

                foreach (Shipping shipping in shippings)
                {
                    _sportsZoneDbContext.Shippings.Remove(shipping);
                }
                await _sportsZoneDbContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}

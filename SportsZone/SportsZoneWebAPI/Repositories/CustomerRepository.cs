using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using SportsZoneWebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace SportsZoneWebAPI.Repositories
{
    public class CustomerRepository
    {
        private readonly SportsZoneDbContext _sportsZoneDbContext;
        public CustomerRepository(SportsZoneDbContext sportsZoneDbContext)
        {
            _sportsZoneDbContext = sportsZoneDbContext;
        }

        public async Task<IEnumerable<Customer>> GetAllCustomer()
        {
            try
            {
                return await _sportsZoneDbContext.Customers.ToListAsync();
            }
            catch(Exception)
            {
                throw;
            }            
        }
        public async Task<Customer> GetCustomerByCustomerID(string email)
        {
            try
            {
                return await _sportsZoneDbContext.Customers.FindAsync(email); 
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task CreateCustomer (Customer customer)
        {
            try
            {
                _sportsZoneDbContext.Customers.Add(customer);
                await _sportsZoneDbContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task UpdateCustomer (Customer customer)
        {
            try
            {
                 _sportsZoneDbContext.Customers.Update(customer);
                await _sportsZoneDbContext.SaveChangesAsync();
            }
            catch(Exception)
            {
                throw;
            }
        }

        public async Task DeleteCustomerByCustomerID(string email)
        {
            try
            {
                Customer customer = await _sportsZoneDbContext.Customers.SingleOrDefaultAsync(customer => customer.Email == email);

                if (customer != null)
                {
                    _sportsZoneDbContext.Customers.Remove(customer);
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

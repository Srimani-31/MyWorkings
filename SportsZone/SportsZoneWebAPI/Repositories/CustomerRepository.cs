using Microsoft.EntityFrameworkCore;
using SportsZoneWebAPI.Data.Interfaces;
using SportsZoneWebAPI.Models;
using SportsZoneWebAPI.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SportsZoneWebAPI.Repositories
{
    public class CustomerRepository : ICustomerRespository
    {
        private readonly ISportsZoneDbContext _sportsZoneDbContext;
        private readonly IUtil _util;
        public CustomerRepository(ISportsZoneDbContext sportsZoneDbContext, IUtil util)
        {
            _sportsZoneDbContext = sportsZoneDbContext;
            _util = util;
        }

        public async Task<bool> IsAvail(string email)
        {
            try
            {
                return await _util.IsAvail(dbSet: _sportsZoneDbContext.Customers,stringID: email);
            }
            catch(Exception)
            {
                throw;
            }
        }
        public async Task<IEnumerable<Customer>> GetAllCustomers()
        {
            try
            {
                return await _sportsZoneDbContext.Customers.ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<Customer> GetCustomerByCustomerID(string email)
        {
            try
            {
                Customer customer = await _sportsZoneDbContext.Customers.FindAsync(email);
                return customer;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task CreateCustomer(Customer customer)
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

        public async Task UpdateCustomer(Customer customer)
        {
            try
            {
                _sportsZoneDbContext.Customers.Update(customer);
                await _sportsZoneDbContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task DeleteCustomerByCustomerID(string email)
        {
            try
            {
                Customer customer = await GetCustomerByCustomerID(email);

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
            catch (Exception)
            {
                throw;
            }
        }

        public async Task DeleteAllCustomers()
        {
            try
            {
                IEnumerable<Customer> customers = await GetAllCustomers();
                foreach (Customer customer in customers)
                {
                    _sportsZoneDbContext.Customers.Remove(customer);
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

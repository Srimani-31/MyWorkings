using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using SportsZoneWebAPI.Repositories;
using SportsZoneWebAPI.Models;

namespace SportsZoneWebAPI.Services
{
    public class CustomerService
    {
        private readonly CustomerRepository _customerRepository;
        public CustomerService(CustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<IEnumerable<Customer>> GetAllCustomer()
        {
            try
            {
                IEnumerable<Customer> customers = await _customerRepository.GetAllCustomers();
                return customers;
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
                Customer customer = await _customerRepository.GetCustomerByCustomerID(email);
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
                await _customerRepository.CreateCustomer(customer);
            }
            catch(Exception)
            {
                throw;
            }
        }
        public async Task UpdateCustomer(Customer customer)
        {
            try
            {
                await _customerRepository.UpdateCustomer(customer);
            }
            catch (Exception)
            {
            }
        }
        public async Task DeleteAllCustomers()
        {
            try
            {
                await _customerRepository.DeleteAllCustomers();
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
                await _customerRepository.DeleteCustomerByCustomerID(email);
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}

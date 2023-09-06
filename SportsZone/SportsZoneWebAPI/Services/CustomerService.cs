﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SportsZoneWebAPI.Repositories;
using SportsZoneWebAPI.Models;
using SportsZoneWebAPI.DTOs;
using AutoMapper;

namespace SportsZoneWebAPI.Services
{
    public class CustomerService
    {
        private readonly CustomerRepository _customerRepository;
        private readonly IMapper _mapper;
        public CustomerService(CustomerRepository customerRepository,IMapper mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CustomerResponseDTO>> GetAllCustomers()
        {
            try
            {
                IEnumerable<Customer> customers = await _customerRepository.GetAllCustomers();
                IList<CustomerResponseDTO> customersResponseDTO = new List<CustomerResponseDTO>();
                foreach (Customer customer in customers)
                {
                    CustomerResponseDTO customerResponseDTO = _mapper.Map<CustomerResponseDTO>(customer);
                    customersResponseDTO.Add(customerResponseDTO);
                }
                return customersResponseDTO;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<CustomerResponseDTO> GetCustomerByCustomerID(string email)
        {
            try
            {
                Customer customer = await _customerRepository.GetCustomerByCustomerID(email);
                CustomerResponseDTO customerResponseDTO = _mapper.Map<CustomerResponseDTO>(customer);
                return customerResponseDTO;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task CreateCustomer(CustomerRequestDTO customerRequestDTO)
        {
            try
            {
                Customer customer = _mapper.Map<Customer>(customerRequestDTO);
                customer.CreatedBy = customerRequestDTO.CreatedUpdatedBy;
                customer.CreatedDate = DateTime.Now;

                await _customerRepository.CreateCustomer(customer);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task UpdateCustomer(CustomerRequestDTO customerRequestDTO)
        {
            try
            {
                Customer customer = await _customerRepository.GetCustomerByCustomerID(customerRequestDTO.Email);
                _mapper.Map(customerRequestDTO, customer);

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

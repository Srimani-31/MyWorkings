using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using SportsZoneWebAPI.Repositories;
using SportsZoneWebAPI.Models;
using SportsZoneWebAPI.DTOs;

namespace SportsZoneWebAPI.Services
{
    public class ShippingService
    {
        private readonly ShippingRepository _shippingRepository;
        public ShippingService(ShippingRepository shippingRepository)
        {
            _shippingRepository = shippingRepository;
        }

        public async Task<IEnumerable<Shipping>> GetAllShippingAddressesByCustomerID(string email)
        {
            try
            {
                IEnumerable<Shipping> shippings = await _shippingRepository.GetAllShippingAddressesByCustomerID(email);
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
                Shipping shipping = await _shippingRepository.GetShippingAddressByShippingID(shippingID);
                return shipping;
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
                await _shippingRepository.AddNewShippingAddress(shipping);
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
                await _shippingRepository.UpdateShippingAddress(shipping);
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
                await _shippingRepository.DeleteShippingAddressByShippingID(shippingID);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}

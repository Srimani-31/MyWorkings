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
    public class SecurityService 
    {
        private readonly SecurityRepository _securityRepository;
        public SecurityService(SecurityRepository securityRepository)
        {
            _securityRepository = securityRepository;
        }

        public async Task<SecurityResponseDTO> GetSecurityDetailsByCustomerID(string email)
        {
            try
            {
                SecurityResponseDTO securityResponseDto = await _securityRepository.GetSecurityDetailsByCustomerID(email);
                return securityResponseDto;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task AddSecurityDetails(SecurityRequestDTO securityRequestDto)
        {
            try
            {
                await _securityRepository.AddSecurityDetails(securityRequestDto);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task UpdateCustomer(Security security)
        {
            try
            {
                await _securityRepository.UpdateSecurityDetails(security);
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
                await _securityRepository.DeleteSecurityDetailsByCustomerID(email);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}

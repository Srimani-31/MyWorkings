using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using SportsZoneWebAPI.Repositories;
using SportsZoneWebAPI.Models;
using SportsZoneWebAPI.DTOs;
using AutoMapper;
namespace SportsZoneWebAPI.Services
{
    public class SecurityService
    {
        private readonly SecurityRepository _securityRepository;
        private readonly IMapper _mapper;

        public SecurityService(SecurityRepository securityRepository, IMapper mapper)
        {
            _securityRepository = securityRepository;
            _mapper = mapper;

        }
        public async Task<SecurityResponseDTO> GetSecurityDetailsByCustomerID(string email)
        {
            try
            {
                Security security = await _securityRepository.GetSecurityDetailsByCustomerID(email);
                SecurityResponseDTO securityResponseDto = _mapper.Map<SecurityResponseDTO>(security);
                return securityResponseDto;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task AddSecurityDetails(SecurityRequestDTO securityRequestDTO)
        {
            try
            {
                Security security = _mapper.Map<Security>(securityRequestDTO);
                security.CreatedBy = securityRequestDTO.CreatedUpdatedBy;
                security.CreatedDate = DateTime.Now;
                await _securityRepository.AddSecurityDetails(security);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task UpdateSecurityDetails(SecurityRequestDTO securityRequestDTO)
        {
            try
            {
                Security security = await _securityRepository.GetSecurityDetailsByCustomerID(securityRequestDTO.Email);
                _mapper.Map(securityRequestDTO, security);

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

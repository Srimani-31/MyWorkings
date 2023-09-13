using AutoMapper;
using SportsZoneWebAPI.DTOs;
using SportsZoneWebAPI.Models;
using SportsZoneWebAPI.Repositories.Interfaces;
using SportsZoneWebAPI.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SportsZoneWebAPI.Services
{
    public class SecurityService : ISecurityService
    {
        private readonly ISecurityRepository _securityRepository;
        private readonly IMapper _mapper;

        public SecurityService(ISecurityRepository securityRepository, IMapper mapper)
        {
            _securityRepository = securityRepository;
            _mapper = mapper;

        }
        public async Task<IEnumerable<SecurityResponseDTO>> GetAllSecurityDetails()
        {
            try
            {
                IEnumerable<Security> securities = await _securityRepository.GetAllSecurityDetails();
                IList<SecurityResponseDTO> securityResponseDTOs = new List<SecurityResponseDTO>();
                foreach (Security security in securities)
                {
                    SecurityResponseDTO securityResponseDTO = _mapper.Map<SecurityResponseDTO>(security);
                    securityResponseDTOs.Add(securityResponseDTO);
                }
                return securityResponseDTOs;
            }
            catch (Exception)
            {
                throw;
            }
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

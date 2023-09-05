using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using SportsZoneWebAPI.Models;
using Microsoft.EntityFrameworkCore;
using SportsZoneWebAPI.DTOs;
using AutoMapper;

namespace SportsZoneWebAPI.Repositories
{
    public class SecurityRepository
    {
        private readonly SportsZoneDbContext _sportsZoneDbContext;
        private readonly IMapper _mapper;
        public SecurityRepository(SportsZoneDbContext sportsZoneDbContext,IMapper mapper)
        {
            _sportsZoneDbContext = sportsZoneDbContext;
            _mapper = mapper;
        }

        public async Task<SecurityResponseDTO> GetSecurityDetailsByCustomerID(string email)
        {
            try
            {
                Security security = await _sportsZoneDbContext.Securities.FindAsync(email);
                SecurityResponseDTO securityResponseDto = _mapper.Map<SecurityResponseDTO>(security);
                return securityResponseDto;
            }
            catch(Exception)
            {
                throw;
            }
        }

        public async Task AddSecurityDetails(SecurityRequestDTO securityRequestDto)
        {
            try
            {
                byte[] password = Util.HashItemToBytes(securityRequestDto.NormalPassword);
                byte[] answer = Util.HashItemToBytes(securityRequestDto.NormalAnswer);

                Security security = _mapper.Map<Security>(securityRequestDto);
                security.Answer = answer;
                security.Password = password;
                security.CreatedBy = securityRequestDto.CreatedUpdatedBy;
                security.CreatedDate = DateTime.Now;
                security.UpdatedBy = securityRequestDto.CreatedUpdatedBy;
                security.UpdatedDate = DateTime.Now;

                _sportsZoneDbContext.Securities.Add(security);
                await _sportsZoneDbContext.SaveChangesAsync();
            }
            catch(Exception)
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
            catch(Exception)
            {
                throw;
            }
        }

        public async Task DeleteSecurityDetailsByCustomerID(string email)
        {
            try
            {
                Security security = _sportsZoneDbContext.Securities.SingleOrDefault(security => security.Email == email);
                if(security != null)
                {
                    _sportsZoneDbContext.Securities.Remove(security);
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

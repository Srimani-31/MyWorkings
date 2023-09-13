using AutoMapper;
using SportsZoneWebAPI.DTOs;
using SportsZoneWebAPI.Models;
using SportsZoneWebAPI.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SportsZoneWebAPI.Services.Interfaces;

namespace SportsZoneWebAPI.Services
{
    public class ShippingService : IShippingService
    {
        private readonly IShippingRepository _shippingRepository;
        private readonly IMapper _mapper;
        public ShippingService(IShippingRepository shippingRepository, IMapper mapper)
        {
            _shippingRepository = shippingRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<ShippingResponseDTO>> GetAllShippingAddresses()
        {
            try
            {
                IEnumerable<Shipping> shippings = await _shippingRepository.GetAllShippingAddresses();
                IList<ShippingResponseDTO> shippingResponseDTOs = new List<ShippingResponseDTO>();
                foreach (Shipping shipping in shippings)
                {
                    ShippingResponseDTO shippingResponseDTO = _mapper.Map<ShippingResponseDTO>(shipping);
                    shippingResponseDTOs.Add(shippingResponseDTO);
                }
                return shippingResponseDTOs;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<ShippingResponseDTO>> GetAllShippingAddressesByCustomerID(string email)
        {
            try
            {
                IEnumerable<Shipping> shippings = await _shippingRepository.GetAllShippingAddressesByCustomerID(email);
                IList<ShippingResponseDTO> shippingResponseDTOs = new List<ShippingResponseDTO>();
                foreach (Shipping shipping in shippings)
                {
                    ShippingResponseDTO shippingResponseDTO = _mapper.Map<ShippingResponseDTO>(shipping);
                    shippingResponseDTOs.Add(shippingResponseDTO);
                }
                return shippingResponseDTOs;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<ShippingResponseDTO> GetShippingAddressByShippingID(int shippingID)
        {
            try
            {
                Shipping shipping = await _shippingRepository.GetShippingAddressByShippingID(shippingID);
                ShippingResponseDTO shippingResponseDTO = _mapper.Map<ShippingResponseDTO>(shipping);

                return shippingResponseDTO;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task AddNewShippingAddress(ShippingRequestDTO shippingRequestDTO)
        {
            try
            {
                Shipping shipping = _mapper.Map<Shipping>(shippingRequestDTO);
                shipping.CreatedBy = shippingRequestDTO.CreatedUpdatedBy;
                shipping.CreatedDate = DateTime.Now;

                await _shippingRepository.AddNewShippingAddress(shipping);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task UpdateShippingAddress(ShippingRequestDTO shippingRequestDTO)
        {
            try
            {
                Shipping shipping = await _shippingRepository.GetShippingAddressByShippingID(shippingRequestDTO.ShippingID);
                _mapper.Map(shippingRequestDTO, shipping);

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

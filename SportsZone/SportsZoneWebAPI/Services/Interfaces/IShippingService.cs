using SportsZoneWebAPI.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace SportsZoneWebAPI.Services.Interfaces
{
    public interface IShippingService
    {
        public Task<bool> IsAvail(int shippingID);
        public Task<IEnumerable<ShippingResponseDTO>> GetAllShippingAddresses();
        public Task<IEnumerable<ShippingResponseDTO>> GetAllShippingAddressesByCustomerID(string email);
        public Task<ShippingResponseDTO> GetShippingAddressByShippingID(int shippingID);
        public Task AddNewShippingAddress(ShippingRequestDTO shippingRequestDTO);
        public Task UpdateShippingAddress(ShippingRequestDTO shippingRequestDTO);
        public Task DeleteShippingAddressByShippingID(int shippingID);
    }
}

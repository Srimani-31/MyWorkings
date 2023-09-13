using SportsZoneWebAPI.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace SportsZoneWebAPI.Services.Interfaces
{
    public interface ICustomerService
    {
        public Task<bool> IsAvail(string email);
        public Task<IEnumerable<CustomerResponseDTO>> GetAllCustomers();
        public Task<CustomerResponseDTO> GetCustomerByCustomerID(string email);
        public Task CreateCustomer(CustomerRequestDTO customerRequestDTO);
        public Task UpdateCustomer(CustomerRequestDTO customerRequestDTO);
        public Task DeleteAllCustomers();
        public Task DeleteCustomerByCustomerID(string email);
    }
}

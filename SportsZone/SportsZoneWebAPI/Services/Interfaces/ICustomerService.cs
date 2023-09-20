using SportsZoneWebAPI.DTOs;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace SportsZoneWebAPI.Services.Interfaces
{
    public interface ICustomerService
    {
        public Task<bool> IsAvail(string email);
        public Task<IEnumerable<CustomerResponseDTO>> GetAllCustomers();
        public Task<CustomerResponseDTO> GetCustomerByCustomerID(string email);
        public Task CreateCustomer(CustomerRequestDTO customerRequestDTO, IFormFile image);
        public Task UpdateCustomer(CustomerRequestDTO customerRequestDTO);
        public Task DeleteAllCustomers();
        public Task DeleteCustomerByCustomerID(string email);
        public FileStream GetImage(string imagePath);
    }
}

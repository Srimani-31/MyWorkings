using SportsZoneWebAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SportsZoneWebAPI.Repositories.Interfaces
{
    public interface ICustomerRespository
    {
        public Task<bool> IsAvail(string email);
        public Task<IEnumerable<Customer>> GetAllCustomers();
        public Task<Customer> GetCustomerByCustomerID(string email);
        public Task CreateCustomer(Customer customer);
        public Task UpdateCustomer(Customer customer);
        public Task DeleteCustomerByCustomerID(string email);
        public Task DeleteAllCustomers();

    }
}

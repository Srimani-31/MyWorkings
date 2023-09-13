using SportsZoneWebAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SportsZoneWebAPI.Repositories.Interfaces
{
    public interface IShippingRepository
    {
        public Task<bool> IsAvail(int shippingID);
        public Task<IEnumerable<Shipping>> GetAllShippingAddresses();
        public Task<IEnumerable<Shipping>> GetAllShippingAddressesByCustomerID(string email);
        public Task<Shipping> GetShippingAddressByShippingID(int shippingID);
        public Task AddNewShippingAddress(Shipping shipping);
        public Task UpdateShippingAddress(Shipping shipping);
        public Task DeleteShippingAddressByShippingID(int shippingID);
        public Task DeleteAllShippingAddresses();
        public Task DeleteAllShippingAddressesByCustomerID(string email);
    }
}

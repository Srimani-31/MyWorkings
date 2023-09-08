using SportsZoneWebAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SportsZoneWebAPI.Repositories.Interfaces
{
    public interface ICartRepository
    {
        public Task<IEnumerable<Cart>> GetAllCarts();
        public Task<IEnumerable<Cart>> GetAllActiveCarts();
        public Task<IEnumerable<Cart>> GetAllOrderedCarts();
        public Task<IEnumerable<Cart>> GetAllCartsByCustomerID(string email);
        public Task<IEnumerable<Cart>> GetAllOrderedCartsByCustomerID(string email);
        public Task<Cart> GetActiveCartByCustomerID(string email);
        public Task<Cart> GetCartByCartID(int cartID);
        public Task AddNewCart(Cart cart);
        public Task UpdateCart(Cart cart);
        public Task DeleteAllCarts();
        public Task DeleteAllOrderedCarts();
        public Task DeleteAllActiveCarts();
        public Task DeleteAllCartsByCustomerID(string email);
        public Task DeleteAllOrderedCartsByCustomerID(string email);
        public Task DeleteActiveCartByCustomerID(string email);
        public Task DeleteCartByCartID(int cartID);


    }
}

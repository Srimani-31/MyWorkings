using SportsZoneWebAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SportsZoneWebAPI.Repositories.Interfaces
{
    public interface ICartItemRepository
    {
        public Task<bool> IsAvail(int cartItemID);
        public Task<IEnumerable<CartItem>> GetAllCartItems();
        public Task<IEnumerable<CartItem>> GetAllCartItemsByCartID(int cartID);
        public Task<CartItem> GetCartItemByCartItemID(int cartID);
        public Task AddNewCartItem(CartItem cartItem);
        public Task UpdateCartItem(CartItem cartItem);
        public Task DeleteAllCartItems();
        public Task DeleteAllCartItemsByCartID(int cartID);
        public Task DeleteCartItemByCartItemID(int cartItemID);
        public Task InsertCartItem(int cartID, int productID, int quantity, string createdBy);
    }
}

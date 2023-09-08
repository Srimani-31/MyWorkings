using SportsZoneWebAPI.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SportsZoneWebAPI.Services.Interfaces
{
    public interface ICartItemService
    {
        public Task<IEnumerable<CartItemResponseDTO>> GetAllCartItems();
        public Task<IEnumerable<CartItemResponseDTO>> GetAllCartItemsByCartID(int cartID);
        public Task<CartItemResponseDTO> GetCartItemByCartItemID(int cartItemID);
        public Task AddNewCartItem(CartItemRequestDTO cartItemRequestDTO);
        public Task UpdateCartItem(CartItemRequestDTO cartItemRequestDTO);
        public Task DeleteCartItemByCartItemID(int cartItemID);
        public Task DeleteAllCartItems();
        public Task DeleteAllCartItemsByCartID(int cartID);
    };
}

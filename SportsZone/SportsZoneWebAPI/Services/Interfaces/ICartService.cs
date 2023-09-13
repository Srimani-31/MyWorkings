using SportsZoneWebAPI.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace SportsZoneWebAPI.Services.Interfaces
{
    public interface ICartService
    {
        public Task<IEnumerable<CartResponseDTO>> GetAllCarts();
        public Task<IEnumerable<CartResponseDTO>> GetAllActiveCarts();
        public Task<CartResponseDTO> GetActiveCartByCustomerID(string email);
        public Task<IEnumerable<CartResponseDTO>> GetAllOrderedCarts();
        public Task<IEnumerable<CartResponseDTO>> GetAllOrderedCartsByCustomerID(string email);
        public Task<IEnumerable<CartResponseDTO>> GetAllCartsByCustomerID(string email);
        public Task<CartResponseDTO> GetCartByCartID(int cartID);
        public Task AddNewCart(CartRequestDTO cartRequestDTO);
        public Task UpdateCart(CartRequestDTO cartRequestDTO);
        public Task DeleteCartByCartID(int cartID);
        public Task DeleteAllCartsByCustomerID(string customerID);
    }
}

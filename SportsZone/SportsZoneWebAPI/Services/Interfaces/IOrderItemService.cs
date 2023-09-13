using SportsZoneWebAPI.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace SportsZoneWebAPI.Services.Interfaces
{
    public interface IOrderItemService
    {
        public Task<IEnumerable<OrderItemResponseDTO>> GetAllOrderedItems();
        public Task<IEnumerable<OrderItemResponseDTO>> GetAllOrderedItemsByOrderID(string orderID);
        public Task<OrderItemResponseDTO> GetOrderItemByOrderItemID(int orderItemID);
        public Task AddNewOrderItem(OrderItemRequestDTO orderItemRequestDTO);
        public Task UpdateOrderItem(OrderItemRequestDTO orderItemRequestDTO);
        public Task DeleteOrderItemByOrderItemID(int orderItemID);
        public Task DeleteAllOrderItems();
        public Task DeleteAllOrderItemsByOrderID(string orderID);
    }
}

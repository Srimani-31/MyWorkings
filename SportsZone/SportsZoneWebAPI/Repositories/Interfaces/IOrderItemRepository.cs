using SportsZoneWebAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace SportsZoneWebAPI.Repositories.Interfaces
{
    public interface IOrderItemRepository
    {
        public Task<bool> IsAvail(int orderItemID);
        public Task<IEnumerable<OrderItem>> GetAllOrderedItems();
        public Task<IEnumerable<OrderItem>> GetAllOrderItemsByOrderID(string orderID);
        public Task<OrderItem> GetOrderItemByOrderItemID(int orderItemID);
        public Task AddNewOrderItem(OrderItem orderItem);
        public Task UpdateOrderItem(OrderItem orderItem);
        public Task DeleteAllOrderItems();
        public Task DeleteAllOrderItemsByOrderID(string orderID);
        public Task DeleteOrderItemByOrderItemID(int orderItemID);
        public Task InsertOrderItemsFromCartItems(string orderID, int cartID);
        public Task InsertOrderItem(string orderID, int productID, int quantity);
    }
}

using SportsZoneWebAPI.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace SportsZoneWebAPI.Services.Interfaces
{
    public interface IOrderService
    {
        public Task<bool> IsAvail(string orderID);
        public Task<IEnumerable<OrderResponseDTO>> GetAllOrders();
        public Task<IEnumerable<OrderResponseDTO>> GetAllOrdersByCustomerID(string email);
        public Task<IEnumerable<OrderResponseDTO>> GetAllPlacedOrders();
        public Task<IEnumerable<OrderResponseDTO>> GetAllPlacedOrdersByCustomerID(string email);
        public Task<IEnumerable<OrderResponseDTO>> GetAllCancelledOrders();
        public Task<IEnumerable<OrderResponseDTO>> GetAllCancelledOrdersByCustomerID(string email);
        public Task<IEnumerable<OrderResponseDTO>> GetAllDeliveredOrders();
        public Task<IEnumerable<OrderResponseDTO>> GetAllDeliveredOrdersByCustomerID(string email);
        public Task<IEnumerable<OrderResponseDTO>> GetAllReturnedOrders();
        public Task<IEnumerable<OrderResponseDTO>> GetAllReturnedOrdersByCustomerID(string email);
        public Task<IEnumerable<OrderResponseDTO>> GetAllOrdersViaCartMode();
        public Task<IEnumerable<OrderResponseDTO>> GetAllOrdersViaCartModeByCustomerID(string email);
        public Task<IEnumerable<OrderResponseDTO>> GetAllOrdersViaDirectPurchase();
        public Task<IEnumerable<OrderResponseDTO>> GetAllOrdersViaDirectPurchaseByCustomerID(string email);
        public Task<OrderResponseDTO> GetOrderByOrderID(string orderID);
        public Task PlaceOrderViaDirectPurchase(OrderRequestDTO orderRequestDTO);
        public Task PlaceOrderViaCartMode(OrderRequestDTO orderRequestDTO);
        public Task CancelOrder(string orderID);
        public Task OrderDelivered(string orderID);
        public Task ReturnOrder(string orderID);
        public Task UpdateOrder(OrderRequestDTO orderRequestDTO);
        public Task DeleteOrderByOrderID(string orderID);
        public Task DeleteOrdersByCustomerID(string email);
        public Task DeleteAllOrders();

    }
}

using SportsZoneWebAPI.DTOs;
using SportsZoneWebAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace SportsZoneWebAPI.Repositories.Interfaces
{
    public interface IOrderRepository
    {
        public Task<bool> IsAvail(string orderID);
        public Task<IEnumerable<Order>> GetAllOrders();
        public Task<IEnumerable<Order>> GetAllOrdersByCustomerID(string email);
        public Task<IEnumerable<Order>> GetAllPlacedOrders();
        public Task<IEnumerable<Order>> GetAllPlacedOrdersByCustomerID(string email);
        public Task<IEnumerable<Order>> GetAllCancelledOrders();
        public Task<IEnumerable<Order>> GetAllCancelledOrdersByCustomerID(string email);
        public Task<IEnumerable<Order>> GetAllDeliveredOrders();
        public Task<IEnumerable<Order>> GetAllDeliveredOrdersByCustomerID(string email);   
        public Task<IEnumerable<Order>> GetAllReturnedOrders();
        public Task<IEnumerable<Order>> GetAllReturnedOrdersByCustomerID(string email);
        public Task<IEnumerable<Order>> GetAllOrdersViaCartMode();
        public Task<IEnumerable<Order>> GetAllOrdersViaCartModeByCustomerID(string email);
        public Task<IEnumerable<Order>> GetAllOrdersViaDirectPurchase();
        public Task<IEnumerable<Order>> GetAllOrdersViaDirectPurchaseByCustomerID(string email);
        public Task<Order> GetOrderByOrderID(string orderID);
        public Task<IEnumerable<Order>> GetAllOrdersByPaymentMode(int paymentID);
        public Task DeleteAllOrders();
        public Task DeleteOrderByOrderID(string orderID);
        public Task DeleteAllOrdersByCustomerID(string email);
        public Task AddNewOrder(Order order);
        public Task UpdateOrder(Order order);
        public Task PlaceOrderViaCartMode(string email, int? cartID, int paymentID, int shippingID);
        public Task PlaceOrderViaDirectPurchase(string email, int productID, int quantity, int paymentID, int shippingID);
        public Task CancelOrder(string orderID);
        public Task OrderDelivered(string orderID);
        public Task ReturnOrder(string orderID);
    }
}

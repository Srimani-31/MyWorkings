using Microsoft.EntityFrameworkCore;
using SportsZoneWebAPI.Data.Interfaces;
using SportsZoneWebAPI.Models;
using SportsZoneWebAPI.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace SportsZoneWebAPI.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ISportsZoneDbContext _sportsZoneDbContext;
        private readonly IOrderItemRepository _orderItemRepository;
        private readonly ICartRepository _cartRepository;
        private readonly ICartItemRepository _cartItemRepository;
        private readonly IProductRepository _productRepository;
        private readonly IUtil _util;
        public OrderRepository(ISportsZoneDbContext sportsZoneDbContext,
            IOrderItemRepository orderItemRepository,
            ICartRepository cartRepository,
            ICartItemRepository cartItemRepository,
            IProductRepository productRepository,
            IUtil util)
        {
            _sportsZoneDbContext = sportsZoneDbContext;
            _orderItemRepository = orderItemRepository;
            _cartRepository = cartRepository;
            _cartItemRepository = cartItemRepository;
            _productRepository = productRepository;
            _util = util;
        }
        public async Task<bool> IsAvail(string orderID)
        {
            try
            {
                return await _util.IsAvail(dbSet: _sportsZoneDbContext.Orders, stringID: orderID);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<IEnumerable<Order>> GetAllOrders()
        {
            try
            {
                return await _sportsZoneDbContext.Orders.ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<IEnumerable<Order>> GetAllOrdersByCustomerID(string email)
        {
            try
            {
                IEnumerable<Order> orders = await _sportsZoneDbContext.Orders
                    .Where(order => order.CustomerID == email)
                    .ToListAsync();
                return orders;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<IEnumerable<Order>> GetAllPlacedOrders()
        {
            try
            {
                IEnumerable<Order> orders = await _sportsZoneDbContext.Orders
                    .Where(order => order.Status == OrderStatus.Placed)
                    .ToListAsync();
                return orders;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<IEnumerable<Order>> GetAllPlacedOrdersByCustomerID(string email)
        {
            try
            {
                IEnumerable<Order> orders = await _sportsZoneDbContext.Orders
                    .Where(order => order.Status == OrderStatus.Placed)
                    .Where(order => order.CustomerID == email)
                    .ToListAsync();
                return orders;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<IEnumerable<Order>> GetAllCancelledOrders()
        {
            try
            {
                IEnumerable<Order> orders = await _sportsZoneDbContext.Orders
                    .Where(order => order.Status == OrderStatus.Cancelled)
                    .ToListAsync();
                return orders;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<IEnumerable<Order>> GetAllCancelledOrdersByCustomerID(string email)
        {
            try
            {
                IEnumerable<Order> orders = await _sportsZoneDbContext.Orders
                    .Where(order => order.Status == OrderStatus.Cancelled)
                    .Where(order => order.CustomerID == email)
                    .ToListAsync();
                return orders;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<IEnumerable<Order>> GetAllDeliveredOrders()
        {
            try
            {
                IEnumerable<Order> orders = await _sportsZoneDbContext.Orders
                    .Where(order => order.Status == OrderStatus.Delivered)
                    .ToListAsync();
                return orders;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<IEnumerable<Order>> GetAllDeliveredOrdersByCustomerID(string email)
        {
            try
            {
                IEnumerable<Order> orders = await _sportsZoneDbContext.Orders
                    .Where(order => order.Status == OrderStatus.Delivered)
                    .Where(order => order.CustomerID == email)
                    .ToListAsync();
                return orders;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<IEnumerable<Order>> GetAllReturnedOrders()
        {
            try
            {
                IEnumerable<Order> orders = await _sportsZoneDbContext.Orders
                    .Where(order => order.Status == OrderStatus.Returned)
                    .ToListAsync();
                return orders;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<IEnumerable<Order>> GetAllReturnedOrdersByCustomerID(string email)
        {
            try
            {
                IEnumerable<Order> orders = await _sportsZoneDbContext.Orders
                    .Where(order => order.Status == OrderStatus.Returned)
                    .Where(order => order.CustomerID == email)
                    .ToListAsync();
                return orders;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<IEnumerable<Order>> GetAllOrdersViaCartMode()
        {
            try
            {
                IEnumerable<Order> orders = await _sportsZoneDbContext.Orders
                    .Where(order => order.CartID != null)
                    .ToListAsync();
                return orders;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<IEnumerable<Order>> GetAllOrdersViaCartModeByCustomerID(string email)
        {
            try
            {
                IEnumerable<Order> orders = await _sportsZoneDbContext.Orders
                    .Where(order => order.CartID != null)
                    .Where(order => order.CustomerID == email)
                    .ToListAsync();
                return orders;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<IEnumerable<Order>> GetAllOrdersViaDirectPurchase()
        {
            try
            {
                IEnumerable<Order> orders = await _sportsZoneDbContext.Orders
                    .Where(order => order.CartID == null)
                    .ToListAsync();
                return orders;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<IEnumerable<Order>> GetAllOrdersViaDirectPurchaseByCustomerID(string email)
        {
            try
            {
                IEnumerable<Order> orders = await _sportsZoneDbContext.Orders
                    .Where(order => order.CartID == null)
                    .Where(order => order.CustomerID == email)
                    .ToListAsync();
                return orders;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<Order> GetOrderByOrderID(string orderID)
        {
            try
            {
                var res = await _sportsZoneDbContext.Orders.FindAsync(orderID);
                return res;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<IEnumerable<Order>> GetAllOrdersByPaymentMode(int paymentID)
        {
            try
            {
                IEnumerable<Order> orders = await _sportsZoneDbContext.Orders
                    .Where(order => order.PaymentID == paymentID)
                    .ToListAsync();
                return orders;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task DeleteAllOrders()
        {
            try
            {
                IEnumerable<Order> orders = await GetAllOrders();
                foreach (Order order in orders)
                {
                    _sportsZoneDbContext.Orders.Remove(order);
                }
                await _sportsZoneDbContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task DeleteOrderByOrderID(string orderID)
        {
            try
            {
                Order order = await GetOrderByOrderID(orderID);

                if (order != null)
                {
                    _sportsZoneDbContext.Orders.Remove(order);
                    await _sportsZoneDbContext.SaveChangesAsync();
                }
                else
                {
                    throw new KeyNotFoundException("Order not found");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task DeleteAllOrdersByCustomerID(string email)
        {
            try
            {
                IEnumerable<Order> orders = await GetAllOrdersByCustomerID(email);
                foreach (Order order in orders)
                {
                    _sportsZoneDbContext.Orders.Remove(order);
                }
                await _sportsZoneDbContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task AddNewOrder(Order order)
        {
            try
            {
                _sportsZoneDbContext.Orders.Add(order);
                await _sportsZoneDbContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task UpdateOrder(Order order)
        {
            try
            {
                _sportsZoneDbContext.Orders.Update(order);
                await _sportsZoneDbContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task PlaceOrderViaCartMode(string email, int? cartID, int paymentID, int shippingID)
        {
            try
            {
                string orderID = _util.GenerateOrderID();
                decimal totalAmount = _util.EvaluateCartTotal((int)cartID);
                Order order = new()
                {
                    OrderID = orderID,
                    OrderDate = DateTime.Now,
                    CustomerID = email,
                    Status = OrderStatus.Placed,
                    TotalAmount = totalAmount,
                    PaymentID = paymentID,
                    ShippingID = shippingID,
                    CartID = cartID,
                    CreatedBy = email,
                    CreatedDate = DateTime.Now,
                    UpdatedBy = email,
                    UpdatedDate = DateTime.Now
                };

                await AddNewOrder(order);

                await _orderItemRepository.InsertOrderItemsFromCartItems(orderID, (int)cartID);

                //update stock count in the product table
                IEnumerable<CartItem> cartItems = await _cartItemRepository.GetAllCartItemsByCartID((int)cartID);
                foreach (CartItem cartItem in cartItems)
                {
                    await _productRepository.UpdateStockCount(cartItem.ProductID, cartItem.Quantity);
                }

                //Disable the cart to the customer
                Cart cart = await _cartRepository.GetCartByCartID((int)cartID);
                cart.IsEnabled = CartStatus.Disabled;
                await _cartRepository.UpdateCart(cart);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task PlaceOrderViaDirectPurchase(string email, int productID, int quantity, int paymentID, int shippingID)
        {
            try
            {
                string orderID = _util.GenerateOrderID();
                decimal totalAmount = _util.CalculateTotalAmountByQuantity(productID, quantity);
                Order order = new()
                {
                    OrderID = orderID,
                    OrderDate = DateTime.Now,
                    CustomerID = email,
                    Status = OrderStatus.Placed,
                    TotalAmount = totalAmount,
                    PaymentID = paymentID,
                    ShippingID = shippingID,
                    CartID = null,
                    CreatedBy = email,
                    CreatedDate = DateTime.Now,
                    UpdatedBy = email,
                    UpdatedDate = DateTime.Now
                };

                await AddNewOrder(order);

                await _orderItemRepository.InsertOrderItem(orderID, productID, quantity);

                //update the product stock cout
                await _productRepository.UpdateStockCount(productID, quantity);

                //Disable the cart to the customer
                Cart cart = await _cartRepository.GetActiveCartByCustomerID(email);
                cart.IsEnabled = CartStatus.Disabled;
                await _cartRepository.UpdateCart(cart);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task CancelOrder(string orderID)
        {
            try
            {
                Order order = await GetOrderByOrderID(orderID);
                order.Status = OrderStatus.Cancelled;
                await UpdateOrder(order);
                IEnumerable<OrderItem> orderItems = _sportsZoneDbContext.OrderItems.Where(x => x.OrderID == orderID);

                foreach (OrderItem orderItem in orderItems)
                {
                    await _productRepository.UpdateStockCount(orderItem.ProductID, orderItem.Quantity, true);
                }
                await _sportsZoneDbContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }

        }
        public async Task ReturnOrder(string orderID)
        {
            try
            {
                Order order = await GetOrderByOrderID(orderID);
                order.Status = OrderStatus.Returned;
                await UpdateOrder(order);
                IEnumerable<OrderItem> orderItems = _sportsZoneDbContext.OrderItems.Where(x => x.OrderID == orderID);

                foreach (OrderItem orderItem in orderItems)
                {
                    await _productRepository.UpdateStockCount(orderItem.ProductID, orderItem.Quantity, true);
                }
                await _sportsZoneDbContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}

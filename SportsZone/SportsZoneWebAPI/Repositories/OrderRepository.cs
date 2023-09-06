using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using SportsZoneWebAPI.Models;

namespace SportsZoneWebAPI.Repositories
{
    public class OrderRepository
    {
        private readonly SportsZoneDbContext _sportsZoneDbContext;
        private readonly OrderItemRepository _orderItemRepository;
        private readonly CartRepository _cartRepository;
        private readonly CartItemRepository _cartItemRepository;
        private readonly ProductRepository _productRepository;
        private readonly Util _util;
        public OrderRepository(SportsZoneDbContext sportsZoneDbContext, 
            OrderItemRepository orderItemRepository,
            CartRepository cartRepository,
            CartItemRepository cartItemRepository,
            ProductRepository productRepository,
            Util util)
        {
            _sportsZoneDbContext = sportsZoneDbContext;
            _orderItemRepository = orderItemRepository;
            _cartRepository = cartRepository;
            _cartItemRepository = cartItemRepository;
            _productRepository = productRepository;
            _util = util;
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
        public async Task<IEnumerable<Order>> GetAllOrdersViaCartMode()
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
        public async Task<IEnumerable<Order>> GetAllDeliveredOrders()
        {
            try
            {
                IEnumerable<Order> orders = await _sportsZoneDbContext.Orders
                    .Where(order => order.Status == "Delivered")
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
                    .Where(order => order.Status == "Cancelled")
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
                    .Where(order => order.Status == "Delivered")
                    .Where(order => order.CustomerID == email)
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
                    .Where(order => order.Status == "Cancelled")
                    .Where(order => order.CustomerID == email)
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
        public async Task<IEnumerable<Order>> GetAllOrdersViaDirectPurchase()
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
        public async Task<IEnumerable<Order>> GetAllOrdersViaDirectPurchaseByCustomerID(string email)
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
        public async Task<Order> GetOrderByOrderID(string orderID)
        {
            try
            {
                return await _sportsZoneDbContext.Orders.FindAsync(orderID);
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
            catch(Exception)
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
            catch(Exception)
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
        public async Task  PlaceOrderViaCartMode(string email, int cartID, int paymentID,int shippingID)
        {
            try
            {
                string orderID = _util.GenerateOrderID();
                decimal totalAmount = _util.EvaluateCartTotal(cartID);
                Order order = new Order()
                {
                    OrderID = orderID,
                    OrderDate = DateTime.Now,
                    CustomerID = email,
                    Status = "Placed",
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

                await _orderItemRepository.InsertOrderItemsFromCartItems(orderID, cartID);

                //update stock count in the product table
                IEnumerable<CartItem> cartItems = await _cartItemRepository.GetAllCartItemsByCartID(cartID);
                foreach(CartItem cartItem in cartItems)
                {
                    await _productRepository.UpdateStockCount(cartItem.ProductID, cartItem.Quantity);
                }

                //Disable the cart to the customer
                Cart cart = await _cartRepository.GetCartByCartID(cartID);
                cart.IsEnabled = false;
                await _cartRepository.UpdateCart(cart);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task PlaceOrderViaDirectPurchase(string email, int productID,int quantity,int paymentID, int shippingID)
        {
            try
            {
                string orderID = _util.GenerateOrderID();
                decimal totalAmount = _util.CalculateTotalAmountByQuantity(productID, quantity);
                Order order = new Order()
                {
                    OrderID = orderID,
                    OrderDate = DateTime.Now,
                    CustomerID = email,
                    Status = "Placed",
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

                await _orderItemRepository.InsertOrderItem(orderID,productID,quantity);

                //update the product stock cout
                await _productRepository.UpdateStockCount(productID, quantity);

                //Disable the cart to the customer
                Cart cart = await _cartRepository.GetActiveCartByCustomerID(email);
                cart.IsEnabled = false;
                await _cartRepository.UpdateCart(cart);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}

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
        public OrderRepository(SportsZoneDbContext sportsZoneDbContext, 
            OrderItemRepository orderItemRepository,
            CartRepository cartRepository,
            CartItemRepository cartItemRepository,
            ProductRepository productRepository)
        {
            _sportsZoneDbContext = sportsZoneDbContext;
            _orderItemRepository = orderItemRepository;
            _cartRepository = cartRepository;
            _cartItemRepository = cartItemRepository;
            _productRepository = productRepository;
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
        public async Task<IEnumerable<Order>> GetAllOrdersViaImmediatePurchaseByCustomerID(string email)
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
        
        public string GenerateOrderID()
        {
            try
            {
                //get timestamp
                DateTime currentDateTime = DateTime.Now;
                string formattedDateTime = currentDateTime.ToString("yyyyMMddHHmmss");

                //generate guid of 4 chars
                string guidPrefix = Guid.NewGuid().ToString("N").Substring(0, 4);

                //get last orderserailnumber and increament it
                string increament = GetOrderSerialNumber(_sportsZoneDbContext.Orders).ToString();

                string orderID = "SPRTZN-" + formattedDateTime + "-" + guidPrefix + "-" + increament;

                return orderID;
            }
            catch(Exception)
            {
                throw;
            }
        }
        public int GetOrderSerialNumber(DbSet<Order> orders)
        {
            try
            {
                // Retrieve the last four digits of OrderID from the database
                IEnumerable<string> lastFourDigits = orders
                    .Select(order => order.OrderID.Substring(order.OrderID.Length - 4))
                    .ToList();

                // Parse the last four digits to integers
                IEnumerable<int> lastFourDigitsInt = lastFourDigits
                    .Select(str => int.TryParse(str, out int value) ? value : 0)
                    .ToList();

                // Calculate the maximum of the parsed integers
                int maxIncrement = lastFourDigitsInt.DefaultIfEmpty().Max();

                int increment = maxIncrement + 1;
                return increment;
            }
            catch(Exception)
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
        public async Task  PlaceOrderViaCartMode(int cartID,string email,int paymentID,int shippingID)
        {
            try
            {
                string orderID = GenerateOrderID();
                decimal totalAmount = await _cartItemRepository.EvaluateCartTotal(cartID);
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
                string orderID = GenerateOrderID();
                decimal totalAmount = _productRepository.CalculateTotalAmountByQuantity(productID, quantity);
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

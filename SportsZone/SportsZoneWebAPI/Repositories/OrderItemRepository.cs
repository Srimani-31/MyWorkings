using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using SportsZoneWebAPI.Models;

namespace SportsZoneWebAPI.Repositories
{
    public class OrderItemRepository
    {
        private readonly SportsZoneDbContext _sportsZoneDbContext;
        private readonly CartItemRepository _cartItemRepository;
        private readonly OrderRepository _orderRepository;
        private readonly ProductRepository _productRepository;        
        public OrderItemRepository(SportsZoneDbContext sportsZoneDbContext
            , CartItemRepository cartItemRepository
            , OrderRepository orderRepository
            ,ProductRepository productRepository)
        {
            _sportsZoneDbContext = sportsZoneDbContext;
            _cartItemRepository = cartItemRepository;
            _orderRepository = orderRepository;
            _productRepository = productRepository;
        }
        public async Task<IEnumerable<OrderItem>> GetAllOrderedItems()
        {
            try
            {
                return await _sportsZoneDbContext.OrderItems.ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<OrderItem>> GetAllOrderItemsByOrderID(string orderID)
        {
            try
            {
                return await _sportsZoneDbContext.OrderItems
                    .Where(orderItem => orderItem.OrderID == orderID)
                    .ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<OrderItem> GetOrderItemByOrderItemID(int orderItemID)
        {
            try
            {
                return await _sportsZoneDbContext.OrderItems.FindAsync(orderItemID);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task AddNewOrderItem(OrderItem orderItem)
        {
            try
            {
                _sportsZoneDbContext.OrderItems.Add(orderItem);
                await _sportsZoneDbContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task UpdateOrderItem(OrderItem orderItem)
        {
            try
            {
                _sportsZoneDbContext.OrderItems.Update(orderItem);
                await _sportsZoneDbContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task DeleteAllOrderItems()
        {
            try
            {
                IEnumerable<OrderItem> orderItems = await GetAllOrderedItems();

                foreach (OrderItem orderItem in orderItems)
                {
                    _sportsZoneDbContext.OrderItems.Remove(orderItem);
                }
                await _sportsZoneDbContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task DeleteAllOrderItemsByOrderID(string orderID)
        {
            try
            {
                IEnumerable<OrderItem> orderItems = await GetAllOrderItemsByOrderID(orderID);

                foreach (OrderItem orderItem in orderItems)
                {
                    _sportsZoneDbContext.OrderItems.Remove(orderItem);
                }
                await _sportsZoneDbContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task DeleteOrderItemByOrderItemID(int orderItemID)
        {
            try
            {
                OrderItem orderItem = await GetOrderItemByOrderItemID(orderItemID);

                _sportsZoneDbContext.OrderItems.Remove(orderItem);
                await _sportsZoneDbContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task InsertOrderItemsFromCartItems(string orderID,int cartID)
        {
            try
            {
                Order order = await _orderRepository.GetOrderByOrderID(orderID);

                IEnumerable<CartItem> cartItems = await _cartItemRepository.GetAllCartItemsByCartID(cartID);

                IEnumerable<OrderItem> orderItems = new List<OrderItem>();

                foreach (CartItem cartItem in cartItems)
                {
                    OrderItem orderItem = new OrderItem()
                    {
                        OrderID = orderID,
                        ProductID = cartItem.ProductID,
                        Quantity = cartItem.Quantity,
                        TotalPrice = cartItem.TotalPrice,
                        CreatedBy = order.CreatedBy,
                        CreatedDate = DateTime.Now,
                        UpdatedBy = order.CreatedBy,
                        UpdatedDate = DateTime.Now
                    };
                    await AddNewOrderItem(orderItem);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task InsertOrderItem(string orderID, int productID, int quantity)
        {
            try
            {
                Order order = await _orderRepository.GetOrderByOrderID(orderID);

                decimal totalPrice = _productRepository.CalculateTotalAmountByQuantity(productID,quantity);

                OrderItem orderItem = new OrderItem()
                {
                    OrderID = orderID,
                    ProductID = productID,
                    Quantity = quantity,
                    TotalPrice = totalPrice,
                    CreatedBy = order.CreatedBy,
                    CreatedDate = DateTime.Now,
                    UpdatedBy = order.CreatedBy,
                    UpdatedDate = DateTime.Now
                };
                await AddNewOrderItem(orderItem);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}

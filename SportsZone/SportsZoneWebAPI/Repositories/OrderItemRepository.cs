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
    public class OrderItemRepository : IOrderItemRepository
    {
        private readonly ISportsZoneDbContext _sportsZoneDbContext;
        private readonly ICartItemRepository _cartItemRepository;
        private readonly IHelper _helper;
        public OrderItemRepository(ISportsZoneDbContext sportsZoneDbContext
            , ICartItemRepository cartItemRepository
            , IHelper util)
        {
            _sportsZoneDbContext = sportsZoneDbContext;
            _cartItemRepository = cartItemRepository;
            _helper = util;
        }
        public async Task<bool> IsAvail(int orderITemID)
        {
            try
            {
                return await _helper.IsAvail(dbSet: _sportsZoneDbContext.OrderItems, intID: orderITemID);
            }
            catch (Exception)
            {
                throw;
            }
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

        public async Task InsertOrderItemsFromCartItems(string orderID, int cartID)
        {
            try
            {
                Order order = await _sportsZoneDbContext.Orders.FindAsync(orderID);

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
                Order order = await _sportsZoneDbContext.Orders.FindAsync(orderID);

                decimal totalPrice = _helper.CalculateTotalAmountByQuantity(productID, quantity);

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

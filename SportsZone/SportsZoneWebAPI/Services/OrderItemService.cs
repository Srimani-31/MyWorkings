using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using SportsZoneWebAPI.Repositories;
using SportsZoneWebAPI.Models;
using SportsZoneWebAPI.DTOs;

namespace SportsZoneWebAPI.Services
{
    public class OrderItemService
    {
        private readonly OrderItemRepository _orderItemRepository;
        public OrderItemService(OrderItemRepository orderItemRepository)
        {
            _orderItemRepository = orderItemRepository;
        }
        public async Task<IEnumerable<OrderItem>> GetAllOrderedItems()
        {
            try
            {
                IEnumerable<OrderItem> orderItems = await _orderItemRepository.GetAllOrderedItems();
                return orderItems;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<IEnumerable<OrderItem>> GetAllOrderedItemsByOrderID(string orderID)
        {
            try
            {
                IEnumerable<OrderItem> orderItems = await _orderItemRepository.GetAllOrderItemsByOrderID(orderID);
                return orderItems;
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
                OrderItem orderItem = await _orderItemRepository.GetOrderItemByOrderItemID(orderItemID);
                return orderItem;
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
                await _orderItemRepository.AddNewOrderItem(orderItem);
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
                await _orderItemRepository.UpdateOrderItem(orderItem);
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
                await _orderItemRepository.DeleteOrderItemByOrderItemID(orderItemID);
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
                await _orderItemRepository.DeleteAllOrderItems();
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
                await _orderItemRepository.DeleteAllOrderItemsByOrderID(orderID);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}

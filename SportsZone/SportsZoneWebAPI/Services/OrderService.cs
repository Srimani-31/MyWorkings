//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//using SportsZoneWebAPI.Repositories;
//using SportsZoneWebAPI.Models;
//using SportsZoneWebAPI.DTOs;

//namespace SportsZoneWebAPI.Services
//{
//    public class OrderService
//    {
//        private readonly OrderRepository _orderRepository;
//        public OrderService(OrderRepository orderRepository)
//        {
//            _orderRepository = orderRepository;
//        }
//        public async Task<IEnumerable<Order>> GetAllOrders()
//        {
//            try
//            {
//                IEnumerable<Order> orders = await _orderRepository.GetAllOrders();
//                return orders;
//            }
//            catch (Exception)
//            {
//                throw;
//            }
//        }
//        public async Task<IEnumerable<Order>> GetAllDeliveredOrders()
//        {
//            try
//            {
//                IEnumerable<Order> orders = await _orderRepository.GetAllDeliveredOrders();
//                return orders;
//            }
//            catch (Exception)
//            {
//                throw;
//            }
//        }
//        public async Task<IEnumerable<Order>> GetAllDeliveredOrdersByCustomerID(string email)
//        {
//            try
//            {
//                IEnumerable<Order> orders = await _orderRepository.GetAllDeliveredOrdersByCustomerID(email);
//                return orders;
//            }
//            catch (Exception)
//            {
//                throw;
//            }
//        }
//        public async Task<IEnumerable<Order>> GetAllCancelledOrders()
//        {
//            try
//            {
//                IEnumerable<Order> orders = await _orderRepository.GetAllCancelledOrders();
//                return orders;
//            }
//            catch (Exception)
//            {
//                throw;
//            }
//        }
//        public async Task<IEnumerable<Order>> GetAllCancelledOrdersByCustomerID(string email)
//        {
//            try
//            {
//                IEnumerable<Order> orders = await _orderRepository.GetAllCancelledOrdersByCustomerID(email);
//                return orders;
//            }
//            catch (Exception)
//            {
//                throw;
//            }
//        }
//        public async Task<IEnumerable<Order>> GetAllOrdersByCustomerID(string email)
//        {
//            try
//            {
//                IEnumerable<Order> orders = await _orderRepository.GetAllOrdersByCustomerID(email);
//                return orders;
//            }
//            catch (Exception)
//            {
//                throw;
//            }
//        }
//        public async Task<IEnumerable<Order>> GetAllOrdersViaCartMode()
//        {
//            try
//            {
//                IEnumerable<Order> orders = await _orderRepository.GetAllOrdersViaCartMode();
//                return orders;
//            }
//            catch (Exception)
//            {
//                throw;
//            }
//        }
//        public async Task<IEnumerable<Order>> GetAllOrdersViaCartModeByCustomerID(string email)
//        {
//            try
//            {
//                IEnumerable<Order> orders = await _orderRepository.GetAllOrdersViaCartModeByCustomerID(email);
//                return orders;
//            }
//            catch (Exception)
//            {
//                throw;
//            }
//        }
        
//        public async Task<IEnumerable<Order>> GetAllOrdersViaDirectPurchase()
//        {
//            try
//            {
//                IEnumerable<Order> orders = await _orderRepository.GetAllOrdersViaDirectPurchase();
//                return orders;
//            }
//            catch (Exception)
//            {
//                throw;
//            }
//        }
//        public async Task<IEnumerable<Order>> GetAllOrdersViaDirectPurchaseByCustomerID(string email)
//        {
//            try
//            {
//                IEnumerable<Order> orders = await _orderRepository.GetAllOrdersViaDirectPurchaseByCustomerID(email);
//                return orders;
//            }
//            catch (Exception)
//            {
//                throw;
//            }
//        }
//        public async Task<Order> GetOrderByOrderID(string orderID)
//        {
//            try
//            {
//                Order order = await _orderRepository.GetOrderByOrderID(orderID);
//                return order;
//            }
//            catch (Exception)
//            {
//                throw;
//            }
//        }
       
//        public async Task PlaceOrderViaDirectPurchase(string email,int productID,int quantity,int paymentID,int shippingID)
//        {
//            try
//            {
//                await _orderRepository.PlaceOrderViaDirectPurchase(email,productID,quantity,paymentID,shippingID);
//            }
//            catch (Exception)
//            {
//                throw;
//            }
//        }
//        public async Task PlaceOrderViaCartMode(string email, int cartID, int quantity, int paymentID, int shippingID)
//        {
//            try
//            {
//                await _orderRepository.PlaceOrderViaCartMode(email, cartID,  paymentID, shippingID);
//            }
//            catch (Exception)
//            {
//                throw;
//            }
//        }

//        public async Task UpdateOrder(Order order)
//        {
//            try
//            {
//                await _orderRepository.UpdateOrder(order);
//            }
//            catch (Exception)
//            {
//                throw;
//            }
//        }
//        public async Task DeleteOrderByOrderID(string orderID)
//        {
//            try
//            {
//                await _orderRepository.DeleteOrderByOrderID(orderID);
//            }
//            catch (Exception)
//            {
//                throw;
//            }
//        }
//        public async Task DeleteOrderByCustomerID(string email)
//        {
//            try
//            {
//                await _orderRepository.DeleteAllOrdersByCustomerID(email);
//            }
//            catch (Exception)
//            {
//                throw;
//            }
//        }
        
//        public async Task DeleteAllOrders()
//        {
//            try
//            {
//                await _orderRepository.DeleteAllOrders();
//            }
//            catch (Exception)
//            {
//                throw;
//            }
//        }
//    }
//}

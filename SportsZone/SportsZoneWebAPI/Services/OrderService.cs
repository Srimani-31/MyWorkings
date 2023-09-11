using AutoMapper;
using SportsZoneWebAPI.DTOs;
using SportsZoneWebAPI.Models;
using SportsZoneWebAPI.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SportsZoneWebAPI.Services.Interfaces;

namespace SportsZoneWebAPI.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;
        public OrderService(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<OrderResponseDTO>> GetAllOrders()
        {
            try
            {
                IEnumerable<Order> orders = await _orderRepository.GetAllOrders();
                IList<OrderResponseDTO> orderResponseDTOs = new List<OrderResponseDTO>();
                foreach (Order order in orders)
                {
                    OrderResponseDTO orderResponseDTO = _mapper.Map<OrderResponseDTO>(order);
                    orderResponseDTOs.Add(orderResponseDTO);
                }
                return orderResponseDTOs;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<IEnumerable<OrderResponseDTO>> GetAllPlacedOrders()
        {
            try
            {
                IEnumerable<Order> orders = await _orderRepository.GetAllPlacedOrders();
                IList<OrderResponseDTO> orderResponseDTOs = new List<OrderResponseDTO>();
                foreach (Order order in orders)
                {
                    OrderResponseDTO orderResponseDTO = _mapper.Map<OrderResponseDTO>(order);
                    orderResponseDTOs.Add(orderResponseDTO);
                }
                return orderResponseDTOs;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<IEnumerable<OrderResponseDTO>> GetAllDeliveredOrders()
        {
            try
            {
                IEnumerable<Order> orders = await _orderRepository.GetAllDeliveredOrders();
                IList<OrderResponseDTO> orderResponseDTOs = new List<OrderResponseDTO>();
                foreach (Order order in orders)
                {
                    OrderResponseDTO orderResponseDTO = _mapper.Map<OrderResponseDTO>(order);
                    orderResponseDTOs.Add(orderResponseDTO);
                }
                return orderResponseDTOs;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<IEnumerable<OrderResponseDTO>> GetAllDeliveredOrdersByCustomerID(string email)
        {
            try
            {
                IEnumerable<Order> orders = await _orderRepository.GetAllDeliveredOrdersByCustomerID(email);
                IList<OrderResponseDTO> orderResponseDTOs = new List<OrderResponseDTO>();
                foreach (Order order in orders)
                {
                    OrderResponseDTO orderResponseDTO = _mapper.Map<OrderResponseDTO>(order);
                    orderResponseDTOs.Add(orderResponseDTO);
                }
                return orderResponseDTOs;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<IEnumerable<OrderResponseDTO>> GetAllCancelledOrders()
        {
            try
            {
                IEnumerable<Order> orders = await _orderRepository.GetAllCancelledOrders();
                IList<OrderResponseDTO> orderResponseDTOs = new List<OrderResponseDTO>();
                foreach (Order order in orders)
                {
                    OrderResponseDTO orderResponseDTO = _mapper.Map<OrderResponseDTO>(order);
                    orderResponseDTOs.Add(orderResponseDTO);
                }
                return orderResponseDTOs;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<IEnumerable<OrderResponseDTO>> GetAllCancelledOrdersByCustomerID(string email)
        {
            try
            {
                IEnumerable<Order> orders = await _orderRepository.GetAllCancelledOrdersByCustomerID(email);
                IList<OrderResponseDTO> orderResponseDTOs = new List<OrderResponseDTO>();
                foreach (Order order in orders)
                {
                    OrderResponseDTO orderResponseDTO = _mapper.Map<OrderResponseDTO>(order);
                    orderResponseDTOs.Add(orderResponseDTO);
                }
                return orderResponseDTOs;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<IEnumerable<OrderResponseDTO>> GetAllOrdersByCustomerID(string email)
        {
            try
            {
                IEnumerable<Order> orders = await _orderRepository.GetAllOrdersByCustomerID(email);
                IList<OrderResponseDTO> orderResponseDTOs = new List<OrderResponseDTO>();
                foreach (Order order in orders)
                {
                    OrderResponseDTO orderResponseDTO = _mapper.Map<OrderResponseDTO>(order);
                    orderResponseDTOs.Add(orderResponseDTO);
                }
                return orderResponseDTOs;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<IEnumerable<OrderResponseDTO>> GetAllOrdersViaCartMode()
        {
            try
            {
                IEnumerable<Order> orders = await _orderRepository.GetAllOrdersViaCartMode();
                IList<OrderResponseDTO> orderResponseDTOs = new List<OrderResponseDTO>();
                foreach (Order order in orders)
                {
                    OrderResponseDTO orderResponseDTO = _mapper.Map<OrderResponseDTO>(order);
                    orderResponseDTOs.Add(orderResponseDTO);
                }
                return orderResponseDTOs;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<IEnumerable<OrderResponseDTO>> GetAllOrdersViaCartModeByCustomerID(string email)
        {
            try
            {
                IEnumerable<Order> orders = await _orderRepository.GetAllOrdersViaCartModeByCustomerID(email);
                IList<OrderResponseDTO> orderResponseDTOs = new List<OrderResponseDTO>();
                foreach (Order order in orders)
                {
                    OrderResponseDTO orderResponseDTO = _mapper.Map<OrderResponseDTO>(order);
                    orderResponseDTOs.Add(orderResponseDTO);
                }
                return orderResponseDTOs;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<IEnumerable<OrderResponseDTO>> GetAllOrdersViaDirectPurchase()
        {
            try
            {
                IEnumerable<Order> orders = await _orderRepository.GetAllOrdersViaDirectPurchase();
                IList<OrderResponseDTO> orderResponseDTOs = new List<OrderResponseDTO>();
                foreach (Order order in orders)
                {
                    OrderResponseDTO orderResponseDTO = _mapper.Map<OrderResponseDTO>(order);
                    orderResponseDTOs.Add(orderResponseDTO);
                }
                return orderResponseDTOs;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<IEnumerable<OrderResponseDTO>> GetAllOrdersViaDirectPurchaseByCustomerID(string email)
        {
            try
            {
                IEnumerable<Order> orders = await _orderRepository.GetAllOrdersViaDirectPurchaseByCustomerID(email);
                IList<OrderResponseDTO> orderResponseDTOs = new List<OrderResponseDTO>();
                foreach (Order order in orders)
                {
                    OrderResponseDTO orderResponseDTO = _mapper.Map<OrderResponseDTO>(order);
                    orderResponseDTOs.Add(orderResponseDTO);
                }
                return orderResponseDTOs;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<OrderResponseDTO> GetOrderByOrderID(string orderID)
        {
            try
            {
                Order order = await _orderRepository.GetOrderByOrderID(orderID);
                OrderResponseDTO orderResponseDTO = _mapper.Map<OrderResponseDTO>(order);
                return orderResponseDTO;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task PlaceOrderViaDirectPurchase(OrderRequestDTO orderRequestDTO)
        {
            try
            {
                await _orderRepository.PlaceOrderViaDirectPurchase(orderRequestDTO.CustomerID,
                    orderRequestDTO.ProductID,
                    orderRequestDTO.Quantity,
                    orderRequestDTO.PaymentID,
                    orderRequestDTO.ShippingID);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task PlaceOrderViaCartMode(OrderRequestDTO orderRequestDTO)
        {
            try
            {
                await _orderRepository.PlaceOrderViaCartMode(orderRequestDTO.CustomerID,
                    orderRequestDTO.CartID,
                    orderRequestDTO.PaymentID,
                    orderRequestDTO.ShippingID);
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
                await _orderRepository.CancelOrder(orderID);
            }
            catch(Exception)
            {
                throw;
            }
        }
        public async Task ReturnOrder(string orderID)
        {
            try
            {
                await _orderRepository.ReturnOrder(orderID);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task UpdateOrder(OrderRequestDTO orderRequestDTO)
        {
            try
            {
                Order order = await _orderRepository.GetOrderByOrderID(orderRequestDTO.OrderID);
                _mapper.Map(orderRequestDTO, order);

                await _orderRepository.UpdateOrder(order);
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
                await _orderRepository.DeleteOrderByOrderID(orderID);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task DeleteOrdersByCustomerID(string email)
        {
            try
            {
                await _orderRepository.DeleteAllOrdersByCustomerID(email);
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
                await _orderRepository.DeleteAllOrders();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}

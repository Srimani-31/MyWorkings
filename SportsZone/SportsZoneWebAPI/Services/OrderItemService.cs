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
    public class OrderItemService : IOrderItemService
    {
        private readonly IOrderItemRepository _orderItemRepository;
        private readonly IMapper _mapper;
        public OrderItemService(IOrderItemRepository orderItemRepository, IMapper mapper)
        {
            _orderItemRepository = orderItemRepository;
            _mapper = mapper;
        }
        public async Task<bool> IsAvail(int orderItemID)
        {
            try
            {
                return await _orderItemRepository.IsAvail(orderItemID);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<IEnumerable<OrderItemResponseDTO>> GetAllOrderedItems()
        {
            try
            {
                IEnumerable<OrderItem> orderItems = await _orderItemRepository.GetAllOrderedItems();
                IList<OrderItemResponseDTO> orderItemResponseDTOs = new List<OrderItemResponseDTO>();
                foreach (OrderItem orderItem in orderItems)
                {
                    OrderItemResponseDTO orderItemResponseDTO = _mapper.Map<OrderItemResponseDTO>(orderItem);
                    orderItemResponseDTOs.Add(orderItemResponseDTO);
                }
                return orderItemResponseDTOs;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<IEnumerable<OrderItemResponseDTO>> GetAllOrderedItemsByOrderID(string orderID)
        {
            try
            {
                IEnumerable<OrderItem> orderItems = await _orderItemRepository.GetAllOrderItemsByOrderID(orderID);
                IList<OrderItemResponseDTO> orderItemResponseDTOs = new List<OrderItemResponseDTO>();
                foreach (OrderItem orderItem in orderItems)
                {
                    OrderItemResponseDTO orderItemResponseDTO = _mapper.Map<OrderItemResponseDTO>(orderItem);
                    orderItemResponseDTOs.Add(orderItemResponseDTO);
                }
                return orderItemResponseDTOs;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<OrderItemResponseDTO> GetOrderItemByOrderItemID(int orderItemID)
        {
            try
            {
                OrderItem orderItem = await _orderItemRepository.GetOrderItemByOrderItemID(orderItemID);
                OrderItemResponseDTO orderItemResponseDTO = _mapper.Map<OrderItemResponseDTO>(orderItem);

                return orderItemResponseDTO;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task AddNewOrderItem(OrderItemRequestDTO orderItemRequestDTO)
        {
            try
            {
                OrderItem orderItem = _mapper.Map<OrderItem>(orderItemRequestDTO);
                orderItem.CreatedBy = orderItemRequestDTO.CreatedUpdatedBy;
                orderItem.CreatedDate = DateTime.Now;

                await _orderItemRepository.AddNewOrderItem(orderItem);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task UpdateOrderItem(OrderItemRequestDTO orderItemRequestDTO)
        {
            try
            {
                OrderItem orderItem = await _orderItemRepository.GetOrderItemByOrderItemID(orderItemRequestDTO.OrderItemID);
                _mapper.Map(orderItemRequestDTO, orderItem);

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

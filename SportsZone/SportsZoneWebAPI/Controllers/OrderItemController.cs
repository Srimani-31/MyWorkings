using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using SportsZoneWebAPI.Repositories;
using SportsZoneWebAPI.Models;
using SportsZoneWebAPI.DTOs;

namespace SportsZoneWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderItemController : ControllerBase
    {
        private readonly OrderItemRepository _orderItemRepository;
        public OrderItemController(OrderItemRepository orderItemRepository)
        {
            _orderItemRepository = orderItemRepository;
        }
        [HttpGet, Route("GetAllOrderedItems")]
        public async Task<ActionResult<IEnumerable<OrderItem>>> GetAllOrderedItems()
        {
            try
            {
                IEnumerable<OrderItem> orderItems = await _orderItemRepository.GetAllOrderedItems();
                return Ok(orderItems);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpGet, Route("GetAllOrderedItemsByOrderID/{orderId}")]
        public async Task<ActionResult<IEnumerable<OrderItem>>> GetAllOrderedItemsByOrderID(string orderID)
        {
            try
            {
                IEnumerable<OrderItem> orderItems = await _orderItemRepository.GetAllOrderItemsByOrderID(orderID);
                return Ok(orderItems);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpGet, Route("GetOrderItemByOrderItemID/{orderItemID}")]
        public async Task<ActionResult<OrderItem>> GetOrderItemByOrderItemID(int orderItemID)
        {
            try
            {
                OrderItem orderItem = await _orderItemRepository.GetOrderItemByOrderItemID(orderItemID);
                return Ok(orderItem);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost, Route("AddNewOrderItem")]
        public async Task<ActionResult<OrderItem>> AddNewOrderItem([FromBody] OrderItem orderItem)
        {
            try
            {
                await _orderItemRepository.AddNewOrderItem(orderItem);
                return Ok(orderItem);
            }
            catch (Exception e)
            {
                return BadRequest(e.InnerException);
            }
        }

        [HttpPut, Route("UpdateOrderItem")]
        public async Task<ActionResult<OrderItem>> UpdateOrderItem([FromBody] OrderItem orderItem)
        {
            try
            {
                await _orderItemRepository.UpdateOrderItem(orderItem);
                return Ok(orderItem);
            }
            catch (Exception e)
            {
                return BadRequest(e.InnerException);
            }
        }

        [HttpDelete, Route("DeleteOrderItemByOrderItemID/{orderItemID}")]
        public async Task<ActionResult> DeleteOrderItemByOrderItemID(int orderItemID)
        {
            try
            {
                await _orderItemRepository.DeleteOrderItemByOrderItemID(orderItemID);
                return Ok($"Order item with ID : {orderItemID} deleted succesfully");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpDelete, Route("DeleteAllOrderItems")]
        public async Task<ActionResult> DeleteAllOrderItems()
        {
            try
            {
                await _orderItemRepository.DeleteAllOrderItems();
                return Ok($"Cart items deleted succesfully");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpDelete, Route("DeleteAllOrderItemsByOrderID/{orderID}")]
        public async Task<ActionResult> DeleteAllOrderItemsByOrderID(string orderID)
        {
            try
            {
                await _orderItemRepository.DeleteAllOrderItemsByOrderID(orderID);
                return Ok($"Order items on the OrderID : {orderID} deleted succesfully");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}

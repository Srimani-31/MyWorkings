using Microsoft.AspNetCore.Mvc;
using SportsZoneWebAPI.DTOs;
using SportsZoneWebAPI.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SportsZoneWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderItemController : ControllerBase
    {
        private readonly IOrderItemService _orderItemService;
        public OrderItemController(IOrderItemService orderItemService)
        {
            _orderItemService = orderItemService;
        }
        [HttpGet, Route("GetAllOrderedItems")]
        public async Task<ActionResult<IEnumerable<OrderItemResponseDTO>>> GetAllOrderedItems()
        {
            try
            {
                IEnumerable<OrderItemResponseDTO> orderItemResponseDTOs = await _orderItemService.GetAllOrderedItems();
                return Ok(orderItemResponseDTOs);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpGet, Route("GetAllOrderedItemsByOrderID/{orderId}")]
        public async Task<ActionResult<IEnumerable<OrderItemResponseDTO>>> GetAllOrderedItemsByOrderID(string orderID)
        {
            try
            {
                IEnumerable<OrderItemResponseDTO> orderItemResponseDTOs = await _orderItemService.GetAllOrderedItemsByOrderID(orderID);
                return Ok(orderItemResponseDTOs);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpGet, Route("GetOrderItemByOrderItemID/{orderItemID}")]
        public async Task<ActionResult<OrderItemResponseDTO>> GetOrderItemByOrderItemID(int orderItemID)
        {
            try
            {
                OrderItemResponseDTO orderItemResponseDTO = await _orderItemService.GetOrderItemByOrderItemID(orderItemID);
                return Ok(orderItemResponseDTO);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost, Route("AddNewOrderItem")]
        public async Task<ActionResult<OrderItemRequestDTO>> AddNewOrderItem([FromBody] OrderItemRequestDTO orderItemRequestDTO)
        {
            try
            {
                await _orderItemService.AddNewOrderItem(orderItemRequestDTO);
                return Ok(orderItemRequestDTO);
            }
            catch (Exception e)
            {
                return BadRequest(e.InnerException);
            }
        }

        [HttpPut, Route("UpdateOrderItem")]
        public async Task<ActionResult<OrderItemRequestDTO>> UpdateOrderItem([FromBody] OrderItemRequestDTO orderItemRequestDTO)
        {
            try
            {
                await _orderItemService.UpdateOrderItem(orderItemRequestDTO);
                return Ok(orderItemRequestDTO);
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
                await _orderItemService.DeleteOrderItemByOrderItemID(orderItemID);
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
                await _orderItemService.DeleteAllOrderItems();
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
                await _orderItemService.DeleteAllOrderItemsByOrderID(orderID);
                return Ok($"Order items on the OrderID : {orderID} deleted succesfully");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}

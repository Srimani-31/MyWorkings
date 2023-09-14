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
   
        [HttpGet, Route("GetAllOrderedItemsByOrderID/{orderID}")]
        public async Task<ActionResult<IEnumerable<OrderItemResponseDTO>>> GetAllOrderedItemsByOrderID(string orderID)
        {
            try
            {
                if (string.IsNullOrEmpty(orderID))
                {
                    return BadRequest();
                }
                IEnumerable<OrderItemResponseDTO> orderItemResponseDTOs = await _orderItemService.GetAllOrderedItemsByOrderID(orderID);
                return Ok(orderItemResponseDTOs);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPost, Route("AddNewOrderItem")]
        public async Task<ActionResult<OrderItemRequestDTO>> AddNewOrderItem([FromBody] OrderItemRequestDTO orderItemRequestDTO)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                if (await _orderItemService.IsAvail(orderItemRequestDTO.OrderItemID))
                {
                    return Conflict();
                }
                await _orderItemService.AddNewOrderItem(orderItemRequestDTO);
                return Ok(orderItemRequestDTO);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPut, Route("UpdateOrderItem")]
        public async Task<ActionResult<OrderItemRequestDTO>> UpdateOrderItem([FromBody] OrderItemRequestDTO orderItemRequestDTO)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                if (!await _orderItemService.IsAvail(orderItemRequestDTO.OrderItemID))
                {
                    return NotFound();
                }
                await _orderItemService.UpdateOrderItem(orderItemRequestDTO);
                return Ok(orderItemRequestDTO);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        #region For Report Gerneration

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
                return StatusCode(500, e.Message);
            }
        }
        [HttpGet, Route("GetOrderItemByOrderItemID/{orderItemID}")]
        public async Task<ActionResult<OrderItemResponseDTO>> GetOrderItemByOrderItemID(int orderItemID)
        {
            try
            {
                if (orderItemID == 0)
                {
                    return BadRequest();
                }
                if (!await _orderItemService.IsAvail(orderItemID))
                {
                    return NotFound();
                }
                OrderItemResponseDTO orderItemResponseDTO = await _orderItemService.GetOrderItemByOrderItemID(orderItemID);
                return Ok(orderItemResponseDTO);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        } 
        #endregion

        #region Rare use case
        //[HttpDelete, Route("DeleteOrderItemByOrderItemID/{orderItemID}")]
        //public async Task<ActionResult> DeleteOrderItemByOrderItemID(int orderItemID)
        //{
        //    try
        //    {
        //        if (orderItemID == 0)
        //        {
        //            return BadRequest("Input parameter 'orderItemID' is required and cannot be empty.");
        //        }
        //        if (!await _orderItemService.IsAvail(orderItemID))
        //        {
        //            return NotFound();
        //        }
        //        await _orderItemService.DeleteOrderItemByOrderItemID(orderItemID);
        //        return Ok($"Order item with ID : {orderItemID} deleted succesfully");
        //    }
        //    catch (Exception e)
        //    {
        //        return StatusCode(500, e.Message);
        //    }
        //}
        //[HttpDelete, Route("DeleteAllOrderItems")]
        //public async Task<ActionResult> DeleteAllOrderItems()
        //{
        //    try
        //    {
        //        await _orderItemService.DeleteAllOrderItems();
        //        return Ok($"Cart items deleted succesfully");
        //    }
        //    catch (Exception e)
        //    {
        //        return StatusCode(500, e.Message);
        //    }
        //}
        //[HttpDelete, Route("DeleteAllOrderItemsByOrderID/{orderID}")]
        //public async Task<ActionResult> DeleteAllOrderItemsByOrderID(string orderID)
        //{
        //    try
        //    {
        //        if (string.IsNullOrEmpty(orderID))
        //        {
        //            return BadRequest("Input parameter 'orderID' is required and cannot be empty.");
        //        }

        //        await _orderItemService.DeleteAllOrderItemsByOrderID(orderID);
        //        return Ok($"Order items on the OrderID : {orderID} deleted succesfully");
        //    }
        //    catch (Exception e)
        //    {
        //        return StatusCode(500, e.Message);
        //    }
        //} 
        #endregion
    }
}

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SportsZoneWebAPI.DTOs;
using SportsZoneWebAPI.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SportsZoneWebAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet, Route("GetAllOrders")]
        public async Task<ActionResult<IEnumerable<OrderResponseDTO>>> GetAllOrders()
        {
            try
            {
                IEnumerable<OrderResponseDTO> orderResponseDTOs = await _orderService.GetAllOrders();
                return Ok(orderResponseDTOs);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet, Route("GetAllOrdersByCustomerID/{email}")]
        public async Task<ActionResult<IEnumerable<OrderResponseDTO>>> GetAllOrdersByCustomerID(string email)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(email))
                {
                    return BadRequest();
                }
                IEnumerable<OrderResponseDTO> orderResponseDTOs = await _orderService.GetAllOrdersByCustomerID(email);
                return Ok(orderResponseDTOs);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet, Route("GetOrderByOrderID/{orderID}")]
        public async Task<ActionResult<OrderResponseDTO>> GetOrderByOrderID(string orderID)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(orderID))
                {
                    return BadRequest();
                }
                if (!await _orderService.IsAvail(orderID))
                {
                    return NotFound();
                }
                OrderResponseDTO orderResponseDTO = await _orderService.GetOrderByOrderID(orderID);
                return Ok(orderResponseDTO);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPost, Route("PlaceOrderViaDirectPurchase")]
        public async Task<ActionResult<OrderRequestDTO>> PlaceOrderViaDirectPurchase(OrderRequestDTO orderRequestDTO)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                if (await _orderService.IsAvail(orderRequestDTO.OrderID))
                {
                    return Conflict();
                }
                await _orderService.PlaceOrderViaDirectPurchase(orderRequestDTO);
                return Ok($"Ordered placed successfully");
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPost, Route("PlaceOrderViaCartMode")]
        public async Task<ActionResult<OrderRequestDTO>> PlaceOrderViaCartMode([FromBody] OrderRequestDTO orderRequestDTO)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                if (await _orderService.IsAvail(orderRequestDTO.OrderID))
                {
                    return Conflict();
                }
                await _orderService.PlaceOrderViaCartMode(orderRequestDTO);
                return Ok($"Ordered placed successfully");
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPut, Route("CancelOrder/{orderID}")]
        public async Task<ActionResult> CancelOrder(string orderID)
        {
            try
            {
                if (string.IsNullOrEmpty(orderID))
                {
                    return BadRequest();
                }
                if (!await _orderService.IsAvail(orderID))
                {
                    return NotFound();
                }
                await _orderService.CancelOrder(orderID);
                return Ok($"Order with ID: {orderID} cancelled successfully");
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPut, Route("OrderDelivered/{orderID}")]
        public async Task<ActionResult> OrderDelivered(string orderID)
        {
            try
            {
                if (string.IsNullOrEmpty(orderID))
                {
                    return BadRequest();
                }
                if (!await _orderService.IsAvail(orderID))
                {
                    return NotFound();
                }
                await _orderService.OrderDelivered(orderID);
                return Ok($"Order with ID: {orderID} delivered successfully");
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPut, Route("ReturnOrder/{orderID}")]
        public async Task<ActionResult> ReturnOrder(string orderID)
        {
            try
            {
                if (string.IsNullOrEmpty(orderID))
                {
                    return BadRequest();
                }
                if (!await _orderService.IsAvail(orderID))
                {
                    return NotFound();
                }
                await _orderService.ReturnOrder(orderID);
                return Ok($"Order with ID: {orderID} returned successfully");
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPut, Route("UpdateOrder")]
        public async Task<ActionResult<OrderRequestDTO>> UpdateOrder([FromBody] OrderRequestDTO orderRequestDTO)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                if (!await _orderService.IsAvail(orderRequestDTO.OrderID))
                {
                    return NotFound();
                }
                await _orderService.UpdateOrder(orderRequestDTO);
                return Ok(orderRequestDTO);
            }
            catch (Exception e)
            {
                return BadRequest(e.InnerException);
            }
        }

        [HttpDelete, Route("DeleteOrderByOrderID/{orderID}")]
        public async Task<ActionResult> DeleteOrderByOrderID(string orderID)
        {
            try
            {
                if (string.IsNullOrEmpty(orderID))
                {
                    return BadRequest("Input parameter 'orderID' is required and cannot be empty.");
                }
                if (!await _orderService.IsAvail(orderID))
                {
                    return NotFound();
                }
                await _orderService.DeleteOrderByOrderID(orderID);
                return Ok($"Order with ID : {orderID} deleted succesfully");
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        #region For Report Generation

        [HttpGet, Route("GetAllPlacedOrders")]
        public async Task<ActionResult<IEnumerable<OrderResponseDTO>>> GetAllPlacedOrders()
        {
            try
            {
                IEnumerable<OrderResponseDTO> orderResponseDTOs = await _orderService.GetAllPlacedOrders();
                return Ok(orderResponseDTOs);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
        [HttpGet, Route("GetAllPlacedOrdersByCustomerID/{email}")]
        public async Task<ActionResult<IEnumerable<OrderResponseDTO>>> GetAllPlacedOrdersByCustomerID(string email)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(email))
                {
                    return BadRequest();
                }
                IEnumerable<OrderResponseDTO> orderResponseDTOs = await _orderService.GetAllPlacedOrdersByCustomerID(email);
                return Ok(orderResponseDTOs);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
        [HttpGet, Route("GetAllCancelledOrders")]
        public async Task<ActionResult<IEnumerable<OrderResponseDTO>>> GetAllCancelledOrders()
        {
            try
            {
                IEnumerable<OrderResponseDTO> orderResponseDTOs = await _orderService.GetAllCancelledOrders();
                return Ok(orderResponseDTOs);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet, Route("GetAllCancelledOrdersByCustomerID/{email}")]
        public async Task<ActionResult<IEnumerable<OrderResponseDTO>>> GetAllCancelledOrdersByCustomerID(string email)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(email))
                {
                    return BadRequest();
                }
                IEnumerable<OrderResponseDTO> orderResponseDTOs = await _orderService.GetAllCancelledOrdersByCustomerID(email);
                return Ok(orderResponseDTOs);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
        [HttpGet, Route("GetAllDeliveredOrders")]
        public async Task<ActionResult<IEnumerable<OrderResponseDTO>>> GetAllDeliveredOrders()
        {
            try
            {
                IEnumerable<OrderResponseDTO> orderResponseDTOs = await _orderService.GetAllDeliveredOrders();
                return Ok(orderResponseDTOs);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
        [HttpGet, Route("GetAllDeliveredOrdersByCustomerID/{email}")]
        public async Task<ActionResult<IEnumerable<OrderResponseDTO>>> GetAllDeliveredOrdersByCustomerID(string email)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(email))
                {
                    return BadRequest();
                }
                IEnumerable<OrderResponseDTO> orderResponseDTOs = await _orderService.GetAllDeliveredOrdersByCustomerID(email);
                return Ok(orderResponseDTOs);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
        [HttpGet, Route("GetAllReturnedOrders")]
        public async Task<ActionResult<IEnumerable<OrderResponseDTO>>> GetAllReturnedOrders()
        {
            try
            {
                IEnumerable<OrderResponseDTO> orderResponseDTOs = await _orderService.GetAllReturnedOrders();
                return Ok(orderResponseDTOs);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
        [HttpGet, Route("GetAllReturnedOrdersByCustomerID/{email}")]
        public async Task<ActionResult<IEnumerable<OrderResponseDTO>>> GetAllReturnedOrdersByCustomerID(string email)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(email))
                {
                    return BadRequest();
                }
                IEnumerable<OrderResponseDTO> orderResponseDTOs = await _orderService.GetAllReturnedOrdersByCustomerID(email);
                return Ok(orderResponseDTOs);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet, Route("GetAllOrdersViaCartMode")]
        public async Task<ActionResult<IEnumerable<OrderResponseDTO>>> GetAllOrdersViaCartMode()
        {
            try
            {
                IEnumerable<OrderResponseDTO> orderResponseDTOs = await _orderService.GetAllOrdersViaCartMode();
                return Ok(orderResponseDTOs);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
        [HttpGet, Route("GetAllOrdersViaCartModeByCustomerID/{email}")]
        public async Task<ActionResult<IEnumerable<OrderResponseDTO>>> GetAllOrdersViaCartModeByCustomerID(string email)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(email))
                {
                    return BadRequest();
                }
                IEnumerable<OrderResponseDTO> orderResponseDTOs = await _orderService.GetAllOrdersViaCartModeByCustomerID(email);
                return Ok(orderResponseDTOs);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet, Route("GetAllOrdersViaDirectPurchase")]
        public async Task<ActionResult<IEnumerable<OrderResponseDTO>>> GetAllOrdersViaDirectPurchase()
        {
            try
            {
                IEnumerable<OrderResponseDTO> orderResponseDTOs = await _orderService.GetAllOrdersViaDirectPurchase();
                return Ok(orderResponseDTOs);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
        [HttpGet, Route("GetAllOrdersViaDirectPurchaseByCustomerID/{email}")]
        public async Task<ActionResult<IEnumerable<OrderResponseDTO>>> GetAllOrdersViaDirectPurchaseByCustomerID(string email)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(email))
                {
                    return BadRequest();
                }
                IEnumerable<OrderResponseDTO> orderResponseDTOs = await _orderService.GetAllOrdersViaDirectPurchaseByCustomerID(email);
                return Ok(orderResponseDTOs);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
        #endregion

        #region Rare use case

        //[HttpDelete, Route("DeleteOrdersByCustomerID/{email}")]
        //public async Task<ActionResult> DeleteOrdersByCustomerID(string email)
        //{
        //    try
        //    {
        //        if (string.IsNullOrEmpty(email))
        //        {
        //            return BadRequest("Input parameter 'email' is required and cannot be empty.");
        //        }

        //        await _orderService.DeleteOrdersByCustomerID(email);
        //        return Ok($"Order belongs to {email} deleted succesfully");
        //    }
        //    catch (Exception e)
        //    {
        //        return StatusCode(500, e.Message);
        //    }
        //}

        //[HttpDelete, Route("DeleteAllOrders")]
        //public async Task<ActionResult> DeleteAllOrders()
        //{
        //    try
        //    {
        //        await _orderService.DeleteAllOrders();
        //        return Ok($"Orders deleted succesfully");
        //    }
        //    catch (Exception e)
        //    {
        //        return StatusCode(500, e.Message);
        //    }
        //} 
        #endregion
    }
}

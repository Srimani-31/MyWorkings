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
                return BadRequest(e.Message);
            }
        }
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
                return BadRequest(e.Message);
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
                return BadRequest(e.Message);
            }
        }
        [HttpGet, Route("GetAllDeliveredOrdersByCustomerID/{email}")]
        public async Task<ActionResult<IEnumerable<OrderResponseDTO>>> GetAllDeliveredOrdersByCustomerID(string email)
        {
            try
            {
                IEnumerable<OrderResponseDTO> orderResponseDTOs = await _orderService.GetAllDeliveredOrdersByCustomerID(email);
                return Ok(orderResponseDTOs);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
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
                return BadRequest(e.Message);
            }
        }
        [HttpGet, Route("GetAllCancelledOrdersByCustomerID/{email}")]
        public async Task<ActionResult<IEnumerable<OrderResponseDTO>>> GetAllCancelledOrdersByCustomerID(string email)
        {
            try
            {
                IEnumerable<OrderResponseDTO> orderResponseDTOs = await _orderService.GetAllCancelledOrdersByCustomerID(email);
                return Ok(orderResponseDTOs);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpGet, Route("GetAllOrdersByCustomerID/{email}")]
        public async Task<ActionResult<IEnumerable<OrderResponseDTO>>> GetAllOrdersByCustomerID(string email)
        {
            try
            {
                IEnumerable<OrderResponseDTO> orderResponseDTOs = await _orderService.GetAllOrdersByCustomerID(email);
                return Ok(orderResponseDTOs);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
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
                return BadRequest(e.Message);
            }
        }
        [HttpGet, Route("GetAllOrdersViaCartModeByCustomerID/{email}")]
        public async Task<ActionResult<IEnumerable<OrderResponseDTO>>> GetAllOrdersViaCartModeByCustomerID(string email)
        {
            try
            {
                IEnumerable<OrderResponseDTO> orderResponseDTOs = await _orderService.GetAllOrdersViaCartModeByCustomerID(email);
                return Ok(orderResponseDTOs);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
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
                return BadRequest(e.Message);
            }
        }
        [HttpGet, Route("GetAllOrdersViaDirectPurchaseByCustomerID/{email}")]
        public async Task<ActionResult<IEnumerable<OrderResponseDTO>>> GetAllOrdersViaDirectPurchaseByCustomerID(string email)
        {
            try
            {
                IEnumerable<OrderResponseDTO> orderResponseDTOs = await _orderService.GetAllOrdersViaDirectPurchaseByCustomerID(email);
                return Ok(orderResponseDTOs);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpGet, Route("GetOrderByOrderID/{orderID}")]
        public async Task<ActionResult<OrderResponseDTO>> GetOrderByOrderID(string orderID)
        {
            try
            {
                OrderResponseDTO orderResponseDTO = await _orderService.GetOrderByOrderID(orderID);
                return Ok(orderResponseDTO);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost, Route("PlaceOrderViaDirectPurchase")]
        public async Task<ActionResult<OrderRequestDTO>> PlaceOrderViaDirectPurchase(OrderRequestDTO orderRequestDTO)
        {
            try
            {
                await _orderService.PlaceOrderViaDirectPurchase(orderRequestDTO);
                return Ok($"Ordered placed successfully");
            }
            catch (Exception e)
            {
                return BadRequest(e.InnerException);
            }
        }
        [HttpPost, Route("PlaceOrderViaCartMode")]
        public async Task<ActionResult<OrderRequestDTO>> PlaceOrderViaCartMode([FromBody] OrderRequestDTO orderRequestDTO)
        {
            try
            {
                await _orderService.PlaceOrderViaCartMode(orderRequestDTO);
                return Ok($"Ordered placed successfully");
            }
            catch (Exception e)
            {
                return BadRequest(e.InnerException);
            }
        }
        [HttpPut,Route("CancelOrder/{orderID}")]
        public async Task<ActionResult> CancelOrder(string orderID)
        {
            try
            {
                await _orderService.CancelOrder(orderID);
                return Ok($"Order with ID: {orderID} cancelled successfully");
            }
            catch(Exception e)
            {
                return BadRequest(e.ToString());
            }
        }

        [HttpPut, Route("ReturnOrder/{orderID}")]
        public async Task<ActionResult> ReturnOrder(string orderID)
        {
            try
            {
                await _orderService.ReturnOrder(orderID);
                return Ok($"Order with ID: {orderID} returned successfully");
            }
            catch (Exception e)
            {
                return BadRequest(e.ToString());
            }
        }
        [HttpPut, Route("UpdateOrder")]
        public async Task<ActionResult<OrderRequestDTO>> UpdateOrder([FromBody] OrderRequestDTO orderRequestDTO)
        {
            try
            {
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
                await _orderService.DeleteOrderByOrderID(orderID);
                return Ok($"Order with ID : {orderID} deleted succesfully");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpDelete, Route("DeleteOrdersByCustomerID/{email}")]
        public async Task<ActionResult> DeleteOrdersByCustomerID(string email)
        {
            try
            {
                await _orderService.DeleteOrdersByCustomerID(email);
                return Ok($"Order belongs to {email} deleted succesfully");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete, Route("DeleteAllOrders")]
        public async Task<ActionResult> DeleteAllOrders()
        {
            try
            {
                await _orderService.DeleteAllOrders();
                return Ok($"Orders deleted succesfully");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}

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
    public class OrderController : ControllerBase
    {
        private readonly OrderRepository _orderRepository;
        public OrderController(OrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }
        [HttpGet, Route("GetAllOrders")]
        public async Task<ActionResult<IEnumerable<Order>>> GetAllOrders()
        {
            try
            {
                IEnumerable<Order> orders = await _orderRepository.GetAllOrders();
                return Ok(orders);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpGet, Route("GetAllDeliveredOrders")]
        public async Task<ActionResult<IEnumerable<Order>>> GetAllDeliveredOrders()
        {
            try
            {
                IEnumerable<Order> orders = await _orderRepository.GetAllDeliveredOrders();
                return Ok(orders);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpGet, Route("GetAllDeliveredOrdersByCustomerID/{email}")]
        public async Task<ActionResult<IEnumerable<Order>>> GetAllDeliveredOrdersByCustomerID(string email)
        {
            try
            {
                IEnumerable<Order> orders = await _orderRepository.GetAllDeliveredOrdersByCustomerID(email);
                return Ok(orders);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpGet, Route("GetAllCancelledOrders")]
        public async Task<ActionResult<IEnumerable<Order>>> GetAllCancelledOrders()
        {
            try
            {
                IEnumerable<Order> orders = await _orderRepository.GetAllCancelledOrders();
                return Ok(orders);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpGet, Route("GetAllCancelledOrdersByCustomerID/{email}")]
        public async Task<ActionResult<IEnumerable<Order>>> GetAllCancelledOrdersByCustomerID(string email)
        {
            try
            {
                IEnumerable<Order> orders = await _orderRepository.GetAllCancelledOrdersByCustomerID(email);
                return Ok(orders);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpGet, Route("GetAllOrdersByCustomerID/{email}")]
        public async Task<ActionResult<IEnumerable<Order>>> GetAllOrdersByCustomerID(string email)
        {
            try
            {
                IEnumerable<Order> orders = await _orderRepository.GetAllOrdersByCustomerID(email);
                return Ok(orders);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpGet, Route("GetAllOrdersViaCartMode")]
        public async Task<ActionResult<IEnumerable<Order>>> GetAllOrdersViaCartMode()
        {
            try
            {
                IEnumerable<Order> orders = await _orderRepository.GetAllOrdersViaCartMode();
                return Ok(orders);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpGet, Route("GetAllOrdersViaCartModeByCustomerID/{email}")]
        public async Task<ActionResult<IEnumerable<Order>>> GetAllOrdersViaCartModeByCustomerID(string email)
        {
            try
            {
                IEnumerable<Order> orders = await _orderRepository.GetAllOrdersViaCartModeByCustomerID(email);
                return Ok(orders);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        
        [HttpGet, Route("GetAllOrdersViaDirectPurchase")]
        public async Task<ActionResult<IEnumerable<Order>>> GetAllOrdersViaDirectPurchase()
        {
            try
            {
                IEnumerable<Order> orders = await _orderRepository.GetAllOrdersViaDirectPurchase();
                return Ok(orders);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpGet, Route("GetAllOrdersViaDirectPurchaseByCustomerID/{email}")]
        public async Task<ActionResult<IEnumerable<Order>>> GetAllOrdersViaDirectPurchaseByCustomerID(string email)
        {
            try
            {
                IEnumerable<Order> orders = await _orderRepository.GetAllOrdersViaDirectPurchaseByCustomerID(email);
                return Ok(orders);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpGet, Route("GetOrderByOrderID/{orderID}")]
        public async Task<ActionResult<Order>> GetOrderByOrderID(string orderID)
        {
            try
            {
                Order order = await _orderRepository.GetOrderByOrderID(orderID);
                return Ok(order);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
       
        [HttpPost, Route("PlaceOrderViaDirectPurchase")]
        public async Task<ActionResult<Order>> PlaceOrderViaDirectPurchase(string email,int productID,int quantity,int paymentID,int shippingID)
        {
            try
            {
                await _orderRepository.PlaceOrderViaDirectPurchase(email,productID,quantity,paymentID,shippingID);
                return Ok($"Ordered placed successfully");
            }
            catch (Exception e)
            {
                return BadRequest(e.InnerException);
            }
        }
        [HttpPost, Route("PlaceOrderViaCartMode")]
        public async Task<ActionResult<Order>> PlaceOrderViaCartMode(string email, int cartID, int quantity, int paymentID, int shippingID)
        {
            try
            {
                await _orderRepository.PlaceOrderViaCartMode(email, cartID,  paymentID, shippingID);
                return Ok($"Ordered placed successfully");
            }
            catch (Exception e)
            {
                return BadRequest(e.InnerException);
            }
        }

        [HttpPut, Route("UpdateOrder")]
        public async Task<ActionResult<Cart>> UpdateOrder([FromBody] Order order)
        {
            try
            {
                await _orderRepository.UpdateOrder(order);
                return Ok(order);
            }
            catch (Exception e)
            {
                return BadRequest(e.InnerException);
            }
        }
        [HttpDelete, Route("DeleteOrderByOrderID/{orderId}")]
        public async Task<ActionResult> DeleteOrderByOrderID(string orderID)
        {
            try
            {
                await _orderRepository.DeleteOrderByOrderID(orderID);
                return Ok($"Order with ID : {orderID} deleted succesfully");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpDelete, Route("DeleteOrderByCustomerID/{email}")]
        public async Task<ActionResult> DeleteOrderByCustomerID(string email)
        {
            try
            {
                await _orderRepository.DeleteAllOrdersByCustomerID(email);
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
                await _orderRepository.DeleteAllOrders();
                return Ok($"Orders deleted succesfully");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}

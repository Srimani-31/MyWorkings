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
    public class CartController : ControllerBase
    {
        private readonly CartRepository _cartRepository;
        public CartController(CartRepository cartRepository)
        {
            _cartRepository = cartRepository;
        }
        [HttpGet, Route("GetAllCarts")]
        public async Task<ActionResult<IEnumerable<Cart>>> GetAllCarts()
        {
            try
            {
                IEnumerable<Cart> carts = await _cartRepository.GetAllCarts();
                return Ok(carts);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpGet, Route("GetAllActiveCarts")]
        public async Task<ActionResult<IEnumerable<Cart>>> GetAllActiveCarts()
        {
            try
            {
                IEnumerable<Cart> carts = await _cartRepository.GetAllActiveCarts();
                return Ok(carts);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpGet, Route("GetActiveCartByCustomerID/{email}")]
        public async Task<ActionResult<Cart>> GetActiveCartByCustomerID(string email)
        {
            try
            {
                Cart cart = await _cartRepository.GetActiveCartByCustomerID(email);
                return Ok(cart);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpGet, Route("GetAllOrderedCarts")]
        public async Task<ActionResult<IEnumerable<Cart>>> GetAllOrderedCarts()
        {
            try
            {
                IEnumerable<Cart> carts = await _cartRepository.GetAllOrderedCarts();
                return Ok(carts);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpGet, Route("GetAllOrderedCartsByCustomerID/{email}")]
        public async Task<ActionResult<IEnumerable<Cart>>> GetAllOrderedCartsByCustomerID(string email)
        {
            try
            {
                IEnumerable<Cart> carts = await _cartRepository.GetAllOrderedCartsByCustomerID(email);
                return Ok(carts);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpGet, Route("GetAllCartsByCustomerID/{email}")]
        public async Task<ActionResult<IEnumerable<Cart>>> GetAllCartsByCustomerID(string email)
        {
            try
            {
                IEnumerable<Cart> carts = await _cartRepository.GetAllCartsByCustomerID(email);
                return Ok(carts);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        [HttpGet, Route("GetCartByCartID/{cartID}")]
        public async Task<ActionResult<Cart>> GetCartByCartID(int cartID)
        {
            try
            {
                Cart cart = await _cartRepository.GetCartByCartID(cartID);
                return Ok(cart);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost, Route("AddNewCart")]
        public async Task<ActionResult<Cart>> AddNewCart([FromBody] Cart cart)
        {
            try
            {
                await _cartRepository.AddNewCart(cart);
                return Ok(cart);
            }
            catch (Exception e)
            {
                return BadRequest(e.InnerException);
            }
        }

        [HttpPut, Route("UpdateCart")]
        public async Task<ActionResult<Cart>> UpdateCart([FromBody] Cart cart)
        {
            try
            {
                await _cartRepository.UpdateCart(cart);
                return Ok(cart);
            }
            catch (Exception e)
            {
                return BadRequest(e.InnerException);
            }
        }
        [HttpDelete, Route("DeleteCartByCartID/{cartID}")]
        public async Task<ActionResult> DeleteCartByCartID(int cartID)
        {
            try
            {
                await _cartRepository.DeleteCartByCartID(cartID);
                return Ok($"Cart with ID : {cartID} deleted succesfully");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete, Route("DeleteAllCartsByCustomerID/{customerID}")]
        public async Task<ActionResult> DeleteAllCartsByCustomerID(string customerID)
        {
            try
            {
                await _cartRepository.DeleteAllCartsByCustomerID(customerID);
                return Ok($"Carts with customerID : {customerID} deleted succesfully");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        
    }
}

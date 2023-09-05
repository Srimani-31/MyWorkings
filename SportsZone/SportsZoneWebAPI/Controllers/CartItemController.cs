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
    public class CartItemController : ControllerBase
    {
        private readonly CartItemRepository _carItemRepository;
        public CartItemController(CartItemRepository cartItemRepository)
        {
            _carItemRepository = cartItemRepository;
        }
        [HttpGet, Route("GetAllCartItems")]
        public async Task<ActionResult<IEnumerable<CartItem>>> GetAllCartItems()
        {
            try
            {
                IEnumerable<CartItem> cartItems = await _carItemRepository.GetAllCartItems();
                return Ok(cartItems);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpGet, Route("GetAllCartItemsByCartID/{cartID}")]
        public async Task<ActionResult<IEnumerable<CartItem>>> GetAllCartItemsByCartID(int cartID)
        {
            try
            {
                IEnumerable<CartItem> cartItems = await _carItemRepository.GetAllCartItemsByCartID(cartID);
                return Ok(cartItems);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpGet, Route("GetCartItemByCartItemID/{cartItemID}")]
        public async Task<ActionResult<CartItem>> GetCartItemByCartItemID(int cartItemID)
        {
            try
            {
                CartItem cartItem = await _carItemRepository.GetCartItemByCartItemID(cartItemID);
                return Ok(cartItem);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost, Route("AddNewCartItem")]
        public async Task<ActionResult<CartItem>> AddNewCartItem([FromBody] CartItem cartItem)
        {
            try
            {
                await _carItemRepository.AddNewCartItem(cartItem);
                return Ok(cartItem);
            }
            catch (Exception e)
            {
                return BadRequest(e.InnerException);
            }
        }

        [HttpPut, Route("UpdateCartItem")]
        public async Task<ActionResult<CartItem>> UpdateCartItem([FromBody] CartItem cartItem)
        {
            try
            {
                await _carItemRepository.UpdateCartItem(cartItem);
                return Ok(cartItem);
            }
            catch (Exception e)
            {
                return BadRequest(e.InnerException);
            }
        }

        [HttpDelete, Route("DeleteCartItemByCartItemID/{cartItemID}")]
        public async Task<ActionResult> DeleteCartItemByCartItemID(int cartItemID)
        {
            try
            {
                await _carItemRepository.DeleteCartItemByCartItemID(cartItemID);
                return Ok($"Cart item with ID : {cartItemID} deleted succesfully");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpDelete, Route("DeleteAllCartItems")]
        public async Task<ActionResult> DeleteAllCartItems()
        {
            try
            {
                await _carItemRepository.DeleteAllCartItems();
                return Ok($"Cart items deleted succesfully");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpDelete, Route("DeleteAllCartItemsByCartID/{cartID}")]
        public async Task<ActionResult> DeleteAllCartItemsByCartID(int cartID)
        {
            try
            {
                await _carItemRepository.DeleteAllCartItemsByCartID(cartID);
                return Ok($"Cart items on the cartID : {cartID} deleted succesfully");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}

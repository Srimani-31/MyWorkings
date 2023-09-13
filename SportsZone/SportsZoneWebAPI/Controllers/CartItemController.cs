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
    public class CartItemController : ControllerBase
    {
        private readonly ICartItemService _cartItemService;
        public CartItemController(ICartItemService cartItemService)
        {
            _cartItemService = cartItemService;
        }
        [HttpGet, Route("GetAllCartItems")]
        public async Task<ActionResult<IEnumerable<CartItemResponseDTO>>> GetAllCartItems()
        {
            try
            {
                IEnumerable<CartItemResponseDTO> cartItemResponseDTOs = await _cartItemService.GetAllCartItems();
                return Ok(cartItemResponseDTOs);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpGet, Route("GetAllCartItemsByCartID/{cartID}")]
        public async Task<ActionResult<IEnumerable<CartItemResponseDTO>>> GetAllCartItemsByCartID(int cartID)
        {
            try
            {
                IEnumerable<CartItemResponseDTO> cartItemResponseDTOs = await _cartItemService.GetAllCartItemsByCartID(cartID);
                return Ok(cartItemResponseDTOs);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpGet, Route("GetCartItemByCartItemID/{cartItemID}")]
        public async Task<ActionResult<CartItemResponseDTO>> GetCartItemByCartItemID(int cartItemID)
        {
            try
            {
                CartItemResponseDTO cartItemResponseDTO = await _cartItemService.GetCartItemByCartItemID(cartItemID);
                return Ok(cartItemResponseDTO);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost, Route("AddNewCartItem")]
        public async Task<ActionResult<CartItemRequestDTO>> AddNewCartItem([FromBody] CartItemRequestDTO cartItemRequestDTO)
        {
            try
            {
                await _cartItemService.AddNewCartItem(cartItemRequestDTO);
                return Ok(cartItemRequestDTO);
            }
            catch (Exception e)
            {
                return BadRequest(e.InnerException);
            }
        }

        [HttpPut, Route("UpdateCartItem")]
        public async Task<ActionResult<CartItemRequestDTO>> UpdateCartItem([FromBody] CartItemRequestDTO cartItemRequestDTO)
        {
            try
            {
                await _cartItemService.UpdateCartItem(cartItemRequestDTO);
                return Ok(cartItemRequestDTO);
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
                await _cartItemService.DeleteCartItemByCartItemID(cartItemID);
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
                await _cartItemService.DeleteAllCartItems();
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
                await _cartItemService.DeleteAllCartItemsByCartID(cartID);
                return Ok($"Cart items on the cartID : {cartID} deleted succesfully");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}

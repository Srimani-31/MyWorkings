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
        [HttpGet, Route("GetAllCartItemsByCartID/{cartID}")]
        public async Task<ActionResult<IEnumerable<CartItemResponseDTO>>> GetAllCartItemsByCartID(int cartID)
        {
            try
            {
                if (cartID == 0)
                {
                    return BadRequest();
                }
                IEnumerable<CartItemResponseDTO> cartItemResponseDTOs = await _cartItemService.GetAllCartItemsByCartID(cartID);
                return Ok(cartItemResponseDTOs);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet, Route("GetCartItemByCartItemID/{cartItemID}")]
        public async Task<ActionResult<CartItemResponseDTO>> GetCartItemByCartItemID(int cartItemID)
        {
            try
            {
                if (cartItemID == 0)
                {
                    return BadRequest();
                }
                if (!await _cartItemService.IsAvail(cartItemID))
                {
                    return NotFound();
                }
                CartItemResponseDTO cartItemResponseDTO = await _cartItemService.GetCartItemByCartItemID(cartItemID);
                return Ok(cartItemResponseDTO);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPost, Route("AddNewCartItem")]
        public async Task<ActionResult<CartItemRequestDTO>> AddNewCartItem([FromBody] CartItemRequestDTO cartItemRequestDTO)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                if (await _cartItemService.IsAvail(cartItemRequestDTO.CartItemID))
                {
                    return Conflict();
                }
                await _cartItemService.AddNewCartItem(cartItemRequestDTO);
                return Ok(cartItemRequestDTO);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
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
                return StatusCode(500, e.Message);
            }
        }
        [HttpDelete, Route("DeleteAllCartItemsByCartID/{cartID}")]
        public async Task<ActionResult> DeleteAllCartItemsByCartID(int cartID)
        {
            try
            {
                if (cartID == 0)
                {
                    return BadRequest("Input parameter 'cartID' is required and cannot be empty.");
                }

                await _cartItemService.DeleteAllCartItemsByCartID(cartID);
                return Ok($"Cart items on the cartID : {cartID} deleted succesfully");
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        #region For Reports
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
                return StatusCode(500, e.Message);
            }
        }
        #endregion

        #region Rare use Case
        //[HttpDelete, Route("DeleteCartItemByCartItemID/{cartItemID}")]
        //public async Task<ActionResult> DeleteCartItemByCartItemID(int cartItemID)
        //{
        //    try
        //    {
        //        if (cartItemID == 0)
        //        {
        //            return BadRequest("Input parameter 'cartItemID' is required and cannot be empty.");
        //        }
        //        if (!await _cartItemService.IsAvail(cartItemID))
        //        {
        //            return NotFound();
        //        }
        //        await _cartItemService.DeleteCartItemByCartItemID(cartItemID);
        //        return Ok($"Cart item with ID : {cartItemID} deleted succesfully");
        //    }
        //    catch (Exception e)
        //    {
        //        return StatusCode(500, e.Message);
        //    }
        //}
        //[HttpDelete, Route("DeleteAllCartItems")]
        //public async Task<ActionResult> DeleteAllCartItems()
        //{
        //    try
        //    {
        //        await _cartItemService.DeleteAllCartItems();
        //        return Ok($"Cart items deleted succesfully");
        //    }
        //    catch (Exception e)
        //    {
        //        return StatusCode(500, e.Message);
        //    }
        //}

        #endregion
    }
}

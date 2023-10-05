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
    public class CartController : ControllerBase
    {
        private readonly ICartService _cartService;
        public CartController(ICartService cartService)
        {
            _cartService = cartService;
        }

        [HttpGet, Route("GetActiveCartByCustomerID/{email}")]
        public async Task<ActionResult<CartResponseDTO>> GetActiveCartByCustomerID(string email)
        {
            try
            {
                if (string.IsNullOrEmpty(email))
                {
                    return BadRequest();
                }
                CartResponseDTO cartResponseDTO = await _cartService.GetActiveCartByCustomerID(email);
                return Ok(cartResponseDTO);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet, Route("GetCartByCartID/{cartID}")]
        public async Task<ActionResult<CartResponseDTO>> GetCartByCartID(int cartID)
        {
            try
            {
                if (cartID == 0)
                {
                    return BadRequest();
                }
                if (!await _cartService.IsAvail(cartID))
                {
                    return NotFound();
                }
                CartResponseDTO cartResponseDTO = await _cartService.GetCartByCartID(cartID);
                return Ok(cartResponseDTO);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPost, Route("AddNewCart")]
        public async Task<ActionResult<CartRequestDTO>> AddNewCart([FromBody] CartRequestDTO cartRequestDTO)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                if (await _cartService.IsAvail(cartRequestDTO.CartID))
                {
                    return Conflict();
                }
                await _cartService.AddNewCart(cartRequestDTO);
                return Ok(cartRequestDTO);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPut, Route("UpdateCart")]
        public async Task<ActionResult<CartRequestDTO>> UpdateCart([FromBody] CartRequestDTO cartRequestDTO)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                if (!await _cartService.IsAvail(cartRequestDTO.CartID))
                {
                    return NotFound();
                }
                await _cartService.UpdateCart(cartRequestDTO);
                return Ok(cartRequestDTO);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpDelete, Route("DeleteCartByCartID/{cartID}")]
        public async Task<ActionResult> DeleteCartByCartID(int cartID)
        {
            try
            {
                if (cartID == 0)
                {
                    return BadRequest("Input parameter 'cartID' is required and cannot be empty.");
                }
                if (!await _cartService.IsAvail(cartID))
                {
                    return NotFound();
                }
                await _cartService.DeleteCartByCartID(cartID);
                return Ok($"Cart with ID : {cartID} deleted succesfully");
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        #region For Report Generation
        [HttpGet, Route("GetAllCarts")]
        public async Task<ActionResult<IEnumerable<CartResponseDTO>>> GetAllCarts()
        {
            try
            {
                IEnumerable<CartResponseDTO> cartResponseDTOs = await _cartService.GetAllCarts();
                return Ok(cartResponseDTOs);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
        [HttpGet, Route("GetAllCartsByCustomerID/{email}")]
        public async Task<ActionResult<IEnumerable<CartResponseDTO>>> GetAllCartsByCustomerID(string email)
        {
            try
            {
                if (string.IsNullOrEmpty(email))
                {
                    return BadRequest();
                }
                IEnumerable<CartResponseDTO> cartResponseDTOs = await _cartService.GetAllCartsByCustomerID(email);
                return Ok(cartResponseDTOs);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
        [HttpGet, Route("GetAllActiveCarts")]
        public async Task<ActionResult<IEnumerable<CartResponseDTO>>> GetAllActiveCarts()
        {
            try
            {
                IEnumerable<CartResponseDTO> cartResponseDTOs = await _cartService.GetAllActiveCarts();
                return Ok(cartResponseDTOs);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet, Route("GetAllOrderedCarts")]
        public async Task<ActionResult<IEnumerable<CartResponseDTO>>> GetAllOrderedCarts()
        {
            try
            {
                IEnumerable<CartResponseDTO> cartResponseDTOs = await _cartService.GetAllOrderedCarts();
                return Ok(cartResponseDTOs);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet, Route("GetAllOrderedCartsByCustomerID/{email}")]
        public async Task<ActionResult<IEnumerable<CartResponseDTO>>> GetAllOrderedCartsByCustomerID(string email)
        {
            try
            {
                if (string.IsNullOrEmpty(email))
                {
                    return BadRequest();
                }
                IEnumerable<CartResponseDTO> cartResponseDTOs = await _cartService.GetAllOrderedCartsByCustomerID(email);
                return Ok(cartResponseDTOs);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
        #endregion

        #region Rare Use Case
        //[HttpDelete, Route("DeleteAllCartsByCustomerID/{customerID}")]
        //public async Task<ActionResult> DeleteAllCartsByCustomerID(string customerID)
        //{
        //    try
        //    {
        //        await _cartService.DeleteAllCartsByCustomerID(customerID);
        //        return Ok($"Carts with customerID : {customerID} deleted succesfully");
        //    }
        //    catch (Exception e)
        //    {
        //        return StatusCode(500, e.Message);
        //    }
        //} 
        #endregion

    }
}

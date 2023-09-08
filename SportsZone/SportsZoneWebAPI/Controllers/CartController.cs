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
                return BadRequest(e.Message);
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
                return BadRequest(e.Message);
            }
        }
        [HttpGet, Route("GetActiveCartByCustomerID/{email}")]
        public async Task<ActionResult<CartResponseDTO>> GetActiveCartByCustomerID(string email)
        {
            try
            {
                CartResponseDTO cartResponseDTO = await _cartService.GetActiveCartByCustomerID(email);
                return Ok(cartResponseDTO);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
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
                return BadRequest(e.Message);
            }
        }
        [HttpGet, Route("GetAllOrderedCartsByCustomerID/{email}")]
        public async Task<ActionResult<IEnumerable<CartResponseDTO>>> GetAllOrderedCartsByCustomerID(string email)
        {
            try
            {
                IEnumerable<CartResponseDTO> cartResponseDTOs = await _cartService.GetAllOrderedCartsByCustomerID(email);
                return Ok(cartResponseDTOs);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpGet, Route("GetAllCartsByCustomerID/{email}")]
        public async Task<ActionResult<IEnumerable<CartResponseDTO>>> GetAllCartsByCustomerID(string email)
        {
            try
            {
                IEnumerable<CartResponseDTO> cartResponseDTOs = await _cartService.GetAllCartsByCustomerID(email);
                return Ok(cartResponseDTOs);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        [HttpGet, Route("GetCartByCartID/{cartID}")]
        public async Task<ActionResult<CartResponseDTO>> GetCartByCartID(int cartID)
        {
            try
            {
                CartResponseDTO cartResponseDTO = await _cartService.GetCartByCartID(cartID);
                return Ok(cartResponseDTO);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost, Route("AddNewCart")]
        public async Task<ActionResult<CartRequestDTO>> AddNewCart([FromBody] CartRequestDTO cartRequestDTO)
        {
            try
            {
                await _cartService.AddNewCart(cartRequestDTO);
                return Ok(cartRequestDTO);
            }
            catch (Exception e)
            {
                return BadRequest(e.InnerException);
            }
        }

        [HttpPut, Route("UpdateCart")]
        public async Task<ActionResult<CartRequestDTO>> UpdateCart([FromBody] CartRequestDTO cartRequestDTO)
        {
            try
            {
                await _cartService.UpdateCart(cartRequestDTO);
                return Ok(cartRequestDTO);
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
                await _cartService.DeleteCartByCartID(cartID);
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
                await _cartService.DeleteAllCartsByCustomerID(customerID);
                return Ok($"Carts with customerID : {customerID} deleted succesfully");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }
}

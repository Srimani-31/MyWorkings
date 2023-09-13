using AutoMapper;
using SportsZoneWebAPI.DTOs;
using SportsZoneWebAPI.Models;
using SportsZoneWebAPI.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SportsZoneWebAPI.Services.Interfaces;

namespace SportsZoneWebAPI.Services
{
    public class CartService : ICartService
    {
        private readonly ICartRepository _cartRepository;
        private readonly IMapper _mapper;
        public CartService(ICartRepository cartRepository, IMapper mapper)
        {
            _cartRepository = cartRepository;
            _mapper = mapper;
        }
        public async Task<bool> IsAvail(int cartID)
        {
            try
            {
                return await _cartRepository.IsAvail(cartID);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<IEnumerable<CartResponseDTO>> GetAllCarts()
        {
            try
            {
                IEnumerable<Cart> carts = await _cartRepository.GetAllCarts();
                IList<CartResponseDTO> cartResponseDTOs = new List<CartResponseDTO>();
                foreach (Cart cart in carts)
                {
                    CartResponseDTO cartResponseDTO = _mapper.Map<CartResponseDTO>(cart);
                    cartResponseDTOs.Add(cartResponseDTO);
                }
                return cartResponseDTOs;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<IEnumerable<CartResponseDTO>> GetAllActiveCarts()
        {
            try
            {
                IEnumerable<Cart> carts = await _cartRepository.GetAllActiveCarts();
                IList<CartResponseDTO> cartResponseDTOs = new List<CartResponseDTO>();
                foreach (Cart cart in carts)
                {
                    CartResponseDTO cartResponseDTO = _mapper.Map<CartResponseDTO>(cart);
                    cartResponseDTOs.Add(cartResponseDTO);
                }
                return cartResponseDTOs;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<CartResponseDTO> GetActiveCartByCustomerID(string email)
        {
            try
            {
                Cart cart = await _cartRepository.GetActiveCartByCustomerID(email);
                CartResponseDTO cartResponseDTO = _mapper.Map<CartResponseDTO>(cart);
                return cartResponseDTO;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<IEnumerable<CartResponseDTO>> GetAllOrderedCarts()
        {
            try
            {
                IEnumerable<Cart> carts = await _cartRepository.GetAllOrderedCarts();
                IList<CartResponseDTO> cartResponseDTOs = new List<CartResponseDTO>();
                foreach (Cart cart in carts)
                {
                    CartResponseDTO cartResponseDTO = _mapper.Map<CartResponseDTO>(cart);
                    cartResponseDTOs.Add(cartResponseDTO);
                }
                return cartResponseDTOs;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<IEnumerable<CartResponseDTO>> GetAllOrderedCartsByCustomerID(string email)
        {
            try
            {
                IEnumerable<Cart> carts = await _cartRepository.GetAllOrderedCartsByCustomerID(email);
                IList<CartResponseDTO> cartResponseDTOs = new List<CartResponseDTO>();
                foreach (Cart cart in carts)
                {
                    CartResponseDTO cartResponseDTO = _mapper.Map<CartResponseDTO>(cart);
                    cartResponseDTOs.Add(cartResponseDTO);
                }
                return cartResponseDTOs;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<IEnumerable<CartResponseDTO>> GetAllCartsByCustomerID(string email)
        {
            try
            {
                IEnumerable<Cart> carts = await _cartRepository.GetAllCartsByCustomerID(email);
                IList<CartResponseDTO> cartResponseDTOs = new List<CartResponseDTO>();
                foreach (Cart cart in carts)
                {
                    CartResponseDTO cartResponseDTO = _mapper.Map<CartResponseDTO>(cart);
                    cartResponseDTOs.Add(cartResponseDTO);
                }
                return cartResponseDTOs;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<CartResponseDTO> GetCartByCartID(int cartID)
        {
            try
            {
                Cart cart = await _cartRepository.GetCartByCartID(cartID);
                CartResponseDTO cartResponseDTO = _mapper.Map<CartResponseDTO>(cart);
                return cartResponseDTO;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task AddNewCart(CartRequestDTO cartRequestDTO)
        {
            try
            {
                Cart cart = _mapper.Map<Cart>(cartRequestDTO);
                cart.CreatedBy = cartRequestDTO.CreatedUpdatedBy;
                cart.CreatedDate = DateTime.Now;

                await _cartRepository.AddNewCart(cart);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task UpdateCart(CartRequestDTO cartRequestDTO)
        {
            try
            {
                Cart cart = await _cartRepository.GetCartByCartID(cartRequestDTO.CartID);
                _mapper.Map(cartRequestDTO, cart);

                await _cartRepository.UpdateCart(cart);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task DeleteCartByCartID(int cartID)
        {
            try
            {
                await _cartRepository.DeleteCartByCartID(cartID);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task DeleteAllCartsByCustomerID(string customerID)
        {
            try
            {
                await _cartRepository.DeleteAllCartsByCustomerID(customerID);
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}

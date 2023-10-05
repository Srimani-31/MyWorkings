using AutoMapper;
using SportsZoneWebAPI.DTOs;
using SportsZoneWebAPI.Models;
using SportsZoneWebAPI.Repositories.Interfaces;
using SportsZoneWebAPI.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SportsZoneWebAPI.Services
{
    public class CartItemService : ICartItemService
    {
        private readonly ICartItemRepository _carItemRepository;
        private readonly IMapper _mapper;
        public CartItemService(ICartItemRepository cartItemRepository, IMapper mapper)
        {
            _carItemRepository = cartItemRepository;
            _mapper = mapper;
        }
        public async Task<bool> IsAvail(int cartItemID)
        {
            try
            {
                return await _carItemRepository.IsAvail(cartItemID);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<IEnumerable<CartItemResponseDTO>> GetAllCartItems()
        {
            try
            {
                IEnumerable<CartItem> cartItems = await _carItemRepository.GetAllCartItems();
                IList<CartItemResponseDTO> cartItemResponseDTOs = new List<CartItemResponseDTO>();
                foreach (CartItem cartItem in cartItems)
                {
                    CartItemResponseDTO cartItemResponseDTO = _mapper.Map<CartItemResponseDTO>(cartItem);
                    cartItemResponseDTOs.Add(cartItemResponseDTO);
                }
                return cartItemResponseDTOs;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<IEnumerable<CartItemResponseDTO>> GetAllCartItemsByCartID(int cartID)
        {
            try
            {
                IEnumerable<CartItem> cartItems = await _carItemRepository.GetAllCartItemsByCartID(cartID);
                IList<CartItemResponseDTO> cartItemResponseDTOs = new List<CartItemResponseDTO>();
                foreach (CartItem cartItem in cartItems)
                {
                    CartItemResponseDTO cartItemResponseDTO = _mapper.Map<CartItemResponseDTO>(cartItem);
                    cartItemResponseDTOs.Add(cartItemResponseDTO);
                }
                return cartItemResponseDTOs;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<CartItemResponseDTO> GetCartItemByCartItemID(int cartItemID)
        {
            try
            {
                CartItem cartItem = await _carItemRepository.GetCartItemByCartItemID(cartItemID);
                CartItemResponseDTO cartItemResponseDTO = _mapper.Map<CartItemResponseDTO>(cartItem);
                return cartItemResponseDTO;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task AddNewCartItem(CartItemRequestDTO cartItemRequestDTO)
        {
            try
            {
                await _carItemRepository.InsertCartItem(cartItemRequestDTO.CartID, cartItemRequestDTO.ProductID, cartItemRequestDTO.Quantity, cartItemRequestDTO.CreatedUpdatedBy);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task UpdateCartItem(CartItemRequestDTO cartItemRequestDTO)
        {
            try
            {
                CartItem cartItem = await _carItemRepository.GetCartItemByCartItemID(cartItemRequestDTO.CartItemID);
                _mapper.Map(cartItemRequestDTO, cartItem);

                await _carItemRepository.UpdateCartItem(cartItem);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task DeleteCartItemByCartItemID(int cartItemID)
        {
            try
            {
                await _carItemRepository.DeleteCartItemByCartItemID(cartItemID);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task DeleteAllCartItems()
        {
            try
            {
                await _carItemRepository.DeleteAllCartItems();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task DeleteAllCartItemsByCartID(int cartID)
        {
            try
            {
                await _carItemRepository.DeleteAllCartItemsByCartID(cartID);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}

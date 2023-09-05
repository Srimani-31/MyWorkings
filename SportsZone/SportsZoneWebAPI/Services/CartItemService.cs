using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using SportsZoneWebAPI.Repositories;
using SportsZoneWebAPI.Models;
using SportsZoneWebAPI.DTOs;

namespace SportsZoneWebAPI.Services
{
    public class CartItemService
    {
        private readonly CartItemRepository _carItemRepository;
        public CartItemService(CartItemRepository cartItemRepository)
        {
            _carItemRepository = cartItemRepository;
        }
        public async Task<IEnumerable<CartItem>> GetAllCartItems()
        {
            try
            {
                IEnumerable<CartItem> cartItems = await _carItemRepository.GetAllCartItems();
                return cartItems;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<IEnumerable<CartItem>> GetAllCartItemsByCartID(int cartID)
        {
            try
            {
                IEnumerable<CartItem> cartItems = await _carItemRepository.GetAllCartItemsByCartID(cartID);
                return cartItems;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<CartItem> GetCartItemByCartItemID(int cartItemID)
        {
            try
            {
                CartItem cartItem = await _carItemRepository.GetCartItemByCartItemID(cartItemID);
                return cartItem;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task AddNewCartItem(CartItem cartItem)
        {
            try
            {
                await _carItemRepository.AddNewCartItem(cartItem);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task UpdateCartItem(CartItem cartItem)
        {
            try
            {
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

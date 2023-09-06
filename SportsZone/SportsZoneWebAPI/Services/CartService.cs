//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//using SportsZoneWebAPI.Repositories;
//using SportsZoneWebAPI.Models;
//using SportsZoneWebAPI.DTOs;

//namespace SportsZoneWebAPI.Services
//{
//    public class CartService
//    {
//        private readonly CartRepository _cartRepository;
//        public CartService(CartRepository cartRepository)
//        {
//            _cartRepository = cartRepository;
//        }
//        public async Task<IEnumerable<Cart>> GetAllCarts()
//        {
//            try
//            {
//                IEnumerable<Cart> carts = await _cartRepository.GetAllCarts();
//                return carts;
//            }
//            catch (Exception)
//            {
//                throw;
//            }
//        }
//        public async Task<IEnumerable<Cart>> GetAllActiveCarts()
//        {
//            try
//            {
//                IEnumerable<Cart> carts = await _cartRepository.GetAllActiveCarts();
//                return carts;
//            }
//            catch (Exception)
//            {
//                throw;
//            }
//        }
//        public async Task<Cart> GetActiveCartByCustomerID(string email)
//        {
//            try
//            {
//                Cart cart = await _cartRepository.GetActiveCartByCustomerID(email);
//                return cart;
//            }
//            catch (Exception)
//            {
//                throw;
//            }
//        }
//        public async Task<IEnumerable<Cart>> GetAllOrderedCarts()
//        {
//            try
//            {
//                IEnumerable<Cart> carts = await _cartRepository.GetAllOrderedCarts();
//                return carts;
//            }
//            catch (Exception)
//            {
//                throw;
//            }
//        }
//        public async Task<IEnumerable<Cart>> GetAllOrderedCartsByCustomerID(string email)
//        {
//            try
//            {
//                IEnumerable<Cart> carts = await _cartRepository.GetAllOrderedCartsByCustomerID(email);
//                return carts;
//            }
//            catch (Exception)
//            {
//                throw;
//            }
//        }
//        public async Task<IEnumerable<Cart>> GetAllCartsByCustomerID(string email)
//        {
//            try
//            {
//                IEnumerable<Cart> carts = await _cartRepository.GetAllCartsByCustomerID(email);
//                return carts;
//            }
//            catch (Exception)
//            {
//                throw;
//            }
//        }
//        public async Task<Cart> GetCartByCartID(int cartID)
//        {
//            try
//            {
//                Cart cart = await _cartRepository.GetCartByCartID(cartID);
//                return cart;
//            }
//            catch (Exception)
//            {
//                throw;
//            }
//        }

//        public async Task AddNewCart(Cart cart)
//        {
//            try
//            {
//                await _cartRepository.AddNewCart(cart);
//            }
//            catch (Exception)
//            {
//                throw;   
//            }
//        }

//        public async Task UpdateCart(Cart cart)
//        {
//            try
//            {
//                await _cartRepository.UpdateCart(cart);
//            }
//            catch (Exception)
//            {
//                throw;
//            }
//        }
//        public async Task DeleteCartByCartID(int cartID)
//        {
//            try
//            {
//                await _cartRepository.DeleteCartByCartID(cartID);
//            }
//            catch (Exception)
//            {
//                throw;
//            }
//        }

//        public async Task DeleteAllCartsByCustomerID(string customerID)
//        {
//            try
//            {
//                await _cartRepository.DeleteAllCartsByCustomerID(customerID);
//            }
//            catch (Exception)
//            {
//                throw;
//            }
//        }
        
//    }
//}

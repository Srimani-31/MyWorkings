using Microsoft.EntityFrameworkCore;
using SportsZoneWebAPI.Data.Interfaces;
using SportsZoneWebAPI.Models;
using SportsZoneWebAPI.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsZoneWebAPI.Repositories
{
    public class CartItemRepository : ICartItemRepository
    {
        private readonly ISportsZoneDbContext _sportsZoneDbContext;
        private readonly IUtil _util;
        public CartItemRepository(ISportsZoneDbContext sportsZoneDbContext, IUtil util)
        {
            _sportsZoneDbContext = sportsZoneDbContext;
            _util = util;
        }
        public async Task<bool> IsAvail(int cartItemID)
        {
            try
            {
                return await _util.IsAvail(dbSet: _sportsZoneDbContext.CartItems, intID: cartItemID);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<IEnumerable<CartItem>> GetAllCartItems()
        {
            try
            {
                return await _sportsZoneDbContext.CartItems.ToListAsync();
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
                return await _sportsZoneDbContext.CartItems.Where(cartItem => cartItem.CartID == cartID).ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<CartItem> GetCartItemByCartItemID(int cartID)
        {
            try
            {
                return await _sportsZoneDbContext.CartItems.FindAsync(cartID);
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
                _sportsZoneDbContext.CartItems.Add(cartItem);
                await _sportsZoneDbContext.SaveChangesAsync();
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
                decimal totalPrice = _util.CalculateTotalAmountByQuantity(cartItem.ProductID, cartItem.Quantity);
                cartItem.TotalPrice = totalPrice;

                _sportsZoneDbContext.CartItems.Update(cartItem);
                await _sportsZoneDbContext.SaveChangesAsync();
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
                IEnumerable<CartItem> cartItems = await GetAllCartItems();

                foreach (CartItem cartItem in cartItems)
                {
                    _sportsZoneDbContext.CartItems.Remove(cartItem);
                }
                await _sportsZoneDbContext.SaveChangesAsync();
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
                IEnumerable<CartItem> cartItems = await GetAllCartItemsByCartID(cartID);

                foreach (CartItem cartItem in cartItems)
                {
                    _sportsZoneDbContext.CartItems.Remove(cartItem);
                }
                await _sportsZoneDbContext.SaveChangesAsync();
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
                CartItem cartItem = await GetCartItemByCartItemID(cartItemID);

                _sportsZoneDbContext.CartItems.Remove(cartItem);
                await _sportsZoneDbContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }


        public async Task InsertCartItem(int cartID, int productID, int quantity, string createdBy)
        {
            try
            {
                // Get the product price by quantity
                decimal totalPrice = _util.CalculateTotalAmountByQuantity(productID, quantity);

                //create cart item
                var cartItem = new CartItem()
                {
                    CartID = cartID,
                    ProductID = productID,
                    Quantity = quantity,
                    TotalPrice = totalPrice,
                    CreatedBy = createdBy,
                    CreatedDate = DateTime.Now,
                    UpdatedBy = createdBy,
                    UpdatedDate = DateTime.Now
                };
                await AddNewCartItem(cartItem);
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}

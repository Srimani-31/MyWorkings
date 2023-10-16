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
    public class CartRepository : ICartRepository
    {
        private readonly ISportsZoneDbContext _sportsZoneDbContext;
        private readonly ICartItemRepository _cartItemRepository;
        private readonly IHelper _helper;
        public CartRepository(ISportsZoneDbContext sportsZoneDbContext, ICartItemRepository cartItemRepository, IHelper helper)
        {
            _sportsZoneDbContext = sportsZoneDbContext;
            _cartItemRepository = cartItemRepository;
            _helper = helper;
        }
        public async Task<bool> IsAvail(int cartID)
        {
            try
            {
                return await _helper.IsAvail(dbSet: _sportsZoneDbContext.Carts, intID: cartID);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<IEnumerable<Cart>> GetAllCarts()
        {
            try
            {
                return await _sportsZoneDbContext.Carts.ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<Cart>> GetAllActiveCarts()
        {
            try
            {
                return await _sportsZoneDbContext.Carts.Where(cart => cart.IsEnabled == true).ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<IEnumerable<Cart>> GetAllOrderedCarts()
        {
            try
            {
                return await _sportsZoneDbContext.Carts.Where(cart => cart.IsEnabled == false).ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<Cart>> GetAllCartsByCustomerID(string email)
        {
            try
            {
                return await _sportsZoneDbContext.Carts.Where(cart => cart.BelongsTo == email).ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<IEnumerable<Cart>> GetAllOrderedCartsByCustomerID(string email)
        {
            try
            {
                return await _sportsZoneDbContext.Carts
                    .Where(cart => cart.BelongsTo == email)
                    .Where(Cart => Cart.IsEnabled == false).ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Cart> GetActiveCartByCustomerID(string email)
        {
            try
            {
                return await _sportsZoneDbContext.Carts
                    .SingleOrDefaultAsync(cart => cart.BelongsTo == email);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<Cart> GetCartByCartID(int cartID)
        {
            try
            {
                return await _sportsZoneDbContext.Carts.FindAsync(cartID);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task AddNewCart(Cart cart)
        {
            try
            {
                _sportsZoneDbContext.Carts.Add(cart);
                await _sportsZoneDbContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task UpdateCart(Cart cart)
        {
            try
            {
                _sportsZoneDbContext.Carts.Update(cart);
                await _sportsZoneDbContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task DeleteAllCarts()
        {
            try
            {
                IEnumerable<Cart> carts = await GetAllCarts();
                foreach (Cart cart in carts)
                {
                    await _cartItemRepository.DeleteAllCartItemsByCartID(cart.CartID);
                    _sportsZoneDbContext.Carts.Remove(cart);
                }
                await _sportsZoneDbContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task DeleteAllOrderedCarts()
        {
            try
            {
                IEnumerable<Cart> carts = await GetAllOrderedCarts();
                foreach (Cart cart in carts)
                {
                    await _cartItemRepository.DeleteAllCartItemsByCartID(cart.CartID);
                    _sportsZoneDbContext.Carts.Remove(cart);
                }
                await _sportsZoneDbContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task DeleteAllActiveCarts()
        {
            try
            {
                IEnumerable<Cart> carts = await GetAllActiveCarts();
                foreach (Cart cart in carts)
                {
                    await _cartItemRepository.DeleteAllCartItemsByCartID(cart.CartID);
                    _sportsZoneDbContext.Carts.Remove(cart);
                }
                await _sportsZoneDbContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task DeleteAllCartsByCustomerID(string email)
        {
            try
            {
                IEnumerable<Cart> carts = await GetAllCartsByCustomerID(email);
                foreach (Cart cart in carts)
                {
                    await _cartItemRepository.DeleteAllCartItemsByCartID(cart.CartID);
                    _sportsZoneDbContext.Carts.Remove(cart);
                }
                await _sportsZoneDbContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task DeleteAllOrderedCartsByCustomerID(string email)
        {
            try
            {
                IEnumerable<Cart> carts = await GetAllOrderedCartsByCustomerID(email);
                foreach (Cart cart in carts)
                {
                    await _cartItemRepository.DeleteAllCartItemsByCartID(cart.CartID);
                    _sportsZoneDbContext.Carts.Remove(cart);
                }
                await _sportsZoneDbContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task DeleteActiveCartByCustomerID(string email)
        {
            try
            {

                Cart cart = _sportsZoneDbContext.Carts
                    .SingleOrDefault(cart =>
                        cart.BelongsTo == email && cart.IsEnabled == true);
                if (cart != null)
                {
                    await _cartItemRepository.DeleteAllCartItemsByCartID(cart.CartID);
                    _sportsZoneDbContext.Carts.Remove(cart);
                    await _sportsZoneDbContext.SaveChangesAsync();
                }
                else
                {
                    throw new KeyNotFoundException("cart not found");
                }
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
                Cart cart = await GetCartByCartID(cartID);
                await _cartItemRepository.DeleteAllCartItemsByCartID(cart.CartID);
                _sportsZoneDbContext.Carts.Remove(cart);
                await _sportsZoneDbContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}

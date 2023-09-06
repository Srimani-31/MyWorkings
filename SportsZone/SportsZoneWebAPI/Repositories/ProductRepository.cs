using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using SportsZoneWebAPI.Models;

namespace SportsZoneWebAPI.Repositories
{
    public class ProductRepository
    {
        private readonly SportsZoneDbContext _sportsZoneDbContext;
        public ProductRepository(SportsZoneDbContext sportsZoneDbContext)
        {
            _sportsZoneDbContext = sportsZoneDbContext;
        }

        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            try
            {
                return await _sportsZoneDbContext.Products.ToListAsync();
            }
            catch(Exception)
            {
                throw;
            }
        }
        public async Task<IEnumerable<Product>> GetAllProductsByCategoryID(int categoryID)
        {
            try
            {
                return await _sportsZoneDbContext.Products.Where(product => product.CategoryID == categoryID).ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Product> GetProductByProductID(int productID)
        {
            try
            {
                return await _sportsZoneDbContext.Products.FindAsync(productID);
            }
            catch(Exception)
            {
                throw;
            }
        }

        public async Task AddNewProduct(Product product)
        {
            try
            {
                _sportsZoneDbContext.Products.Add(product);
                await _sportsZoneDbContext.SaveChangesAsync();
            }
            catch(Exception)
            {
                throw;
            }
        }

        public async Task UpdateProduct(Product product)
        {
            try
            {
                _sportsZoneDbContext.Products.Update(product);
                await _sportsZoneDbContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }
        
        public async Task DeleteProductByProductID(int productID)
        {
            try
            {
                Product product = await _sportsZoneDbContext.Products.SingleOrDefaultAsync(product => product.CategoryID == productID);
                if (product != null)
                {
                    _sportsZoneDbContext.Products.Remove(product);
                }
                else
                {
                    throw new KeyNotFoundException("Category not found");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task DeleteAllProductsByCategoryID(int categoryID)
        {
            try
            {
                IEnumerable<Product> products = await GetAllProductsByCategoryID(categoryID);
                foreach (Product product in products)
                {
                    _sportsZoneDbContext.Products.Remove(product);
                }
                await _sportsZoneDbContext.SaveChangesAsync();

            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task DeleteAllProducts()
        {
            try
            {
                //await _categoryRepository.DeleteAllCategories();
                await _sportsZoneDbContext.SaveChangesAsync();

            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task UpdateStockCount(int productID,int quantityPurchased)
        {
            try
            {
                Product product = await GetProductByProductID(productID);
                product.StockCount = product.StockCount - quantityPurchased;
                await UpdateProduct(product);
            }
            catch(Exception)
            {
                throw;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using SportsZoneWebAPI.Models;

namespace SportsZoneWebAPI.Repositories
{
    public class CategoryRepository
    {
        private readonly SportsZoneDbContext _sportsZoneDbContext;
        public CategoryRepository(SportsZoneDbContext sportsZoneDbContext)
        {
            _sportsZoneDbContext = sportsZoneDbContext;
        }

        public async Task<IEnumerable<Category>> GetAllCategories()
        {
            try
            {
                return await _sportsZoneDbContext.Categories.ToListAsync();
            }
            catch(Exception)
            {
                throw;
            }
        }

        public async Task<Category> GetCategoryByCategoryID(int categoryID)
        {
            try
            {
                return await _sportsZoneDbContext.Categories.FindAsync(categoryID);
            }
            catch(Exception)
            {
                throw;
            }
        }

        public async Task AddNewCategory(Category category)
        {
            try
            {
                _sportsZoneDbContext.Categories.Add(category);
                await _sportsZoneDbContext.SaveChangesAsync();
            }
            catch(Exception)
            {
                throw;
            }
        }

        public async Task UpdateCategory(Category category)
        {
            try
            {
                _sportsZoneDbContext.Categories.Update(category);
                await _sportsZoneDbContext.SaveChangesAsync();
            }
            catch(Exception)
            {
                throw;
            }
        }

        public async Task DeleteCategoryByCategoryID(int categoryID)
        {
            try
            {
                Category category = _sportsZoneDbContext.Categories.SingleOrDefault(category => category.CategoryID == categoryID);
                if (category != null)
                {
                    IEnumerable<Product> products = await _sportsZoneDbContext.Products.Where(product => product.CategoryID == categoryID).ToListAsync();
                    foreach (Product product in products)
                    {
                        _sportsZoneDbContext.Products.Remove(product);
                    }
                    _sportsZoneDbContext.Categories.Remove(category);
                }             
                else
                {
                    throw new KeyNotFoundException("Category not found");
                }                     
            }
            catch(Exception)
            {
                throw;
            }
        }

        public async Task DeleteAllCategories()
        {
            try
            {
                IEnumerable<Category> categories = await GetAllCategories();
                foreach(Category category in categories)
                {
                    IEnumerable<Product> products = await _sportsZoneDbContext.Products.Where(product => product.CategoryID == category.CategoryID).ToListAsync();
                    foreach (Product product in products)
                    {
                        _sportsZoneDbContext.Products.Remove(product);
                    }
                    _sportsZoneDbContext.Categories.Remove(category);
                }
                await _sportsZoneDbContext.SaveChangesAsync();
                
            }
            catch(Exception)
            {
                throw;
            }
        }
    }
}

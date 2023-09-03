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
        private readonly ProductRepository _productRepository;
        public CategoryRepository(SportsZoneDbContext sportsZoneDbContext, ProductRepository productRepository)
        {
            _sportsZoneDbContext = sportsZoneDbContext;
            _productRepository = productRepository;
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
                    await _productRepository.DeleteAllProductsByCategoryID(category.CategoryID);
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
                    await _productRepository.DeleteAllProductsByCategoryID(category.CategoryID);
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

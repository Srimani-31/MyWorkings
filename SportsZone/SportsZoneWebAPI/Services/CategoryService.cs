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
//    public class CategoryService
//    {
//        private readonly CategoryRepository _categoryRepository;
//        public CategoryService(CategoryRepository categoryRepository)
//        {
//            _categoryRepository = categoryRepository;
//        }
//        public async Task<IEnumerable<Category>> GetAllCategories()
//        {
//            try
//            {
//                IEnumerable<Category> categories = await _categoryRepository.GetAllCategories();
//                return categories;
//            }
//            catch (Exception)
//            {
//                throw;
//            }
//        }
//        public async Task<Category> GetCategoryByCategoryID(int categoryID)
//        {
//            try
//            {
//                Category category = await _categoryRepository.GetCategoryByCategoryID(categoryID);
//                return category;
//            }
//            catch (Exception)
//            {
//                throw;
//            }
//        }
//        public async Task AddNewCategory(Category category)
//        {
//            try
//            {
//                await _categoryRepository.AddNewCategory(category);
//            }
//            catch (Exception)
//            {
//                throw;
//            }
//        }

//        public async Task UpdateCategory(Category category)
//        {
//            try
//            {
//                await _categoryRepository.UpdateCategory(category);
//            }
//            catch (Exception)
//            {
//                throw;
//            }
//        }
//        public async Task DeleteCategoryByCategoryID(int categoryID)
//        {
//            try
//            {
//                await _categoryRepository.DeleteCategoryByCategoryID(categoryID);
//            }
//            catch (Exception)
//            {
//                throw;
//            }
//        }
//    }
//}

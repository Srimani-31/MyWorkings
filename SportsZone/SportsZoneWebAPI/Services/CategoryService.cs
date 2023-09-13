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
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRespository _categoryRepository;
        private readonly IMapper _mapper;
        public CategoryService(ICategoryRespository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<CategoryResponseDTO>> GetAllCategories()
        {
            try
            {
                IEnumerable<Category> categories = await _categoryRepository.GetAllCategories();
                IList<CategoryResponseDTO> categoryResponseDTOs = new List<CategoryResponseDTO>();
                foreach (Category category in categories)
                {
                    CategoryResponseDTO categoryResponseDTO = _mapper.Map<CategoryResponseDTO>(category);
                    categoryResponseDTOs.Add(categoryResponseDTO);
                }
                return categoryResponseDTOs;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<CategoryResponseDTO> GetCategoryByCategoryID(int categoryID)
        {
            try
            {
                Category category = await _categoryRepository.GetCategoryByCategoryID(categoryID);
                CategoryResponseDTO categoryResponseDTO = _mapper.Map<CategoryResponseDTO>(category);
                return categoryResponseDTO;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task AddNewCategory(CategoryRequestDTO categoryRequestDTO)
        {
            try
            {
                Category category = _mapper.Map<Category>(categoryRequestDTO);
                category.CreatedBy = categoryRequestDTO.CreatedUpdatedBy;
                category.CreatedDate = DateTime.Now;

                await _categoryRepository.AddNewCategory(category);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task UpdateCategory(CategoryRequestDTO categoryRequestDTO)
        {
            try
            {
                Category category = await _categoryRepository.GetCategoryByCategoryID(categoryRequestDTO.CategoryID);
                _mapper.Map(categoryRequestDTO, category);

                await _categoryRepository.UpdateCategory(category);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task DeleteCategoryByCategoryID(int categoryID)
        {
            try
            {
                await _categoryRepository.DeleteCategoryByCategoryID(categoryID);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}

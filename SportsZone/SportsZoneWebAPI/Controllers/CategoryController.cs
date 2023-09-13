using Microsoft.AspNetCore.Mvc;
using SportsZoneWebAPI.DTOs;
using SportsZoneWebAPI.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SportsZoneWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet, Route("GetAllCategories")]
        public async Task<ActionResult<IEnumerable<CategoryResponseDTO>>> GetAllCategories()
        {
            try
            {
                IEnumerable<CategoryResponseDTO> categoryResponseDTOs = await _categoryService.GetAllCategories();
                return Ok(categoryResponseDTOs);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpGet, Route("GetCategoryByCategoryID/{categoryID}")]
        public async Task<ActionResult<CategoryResponseDTO>> GetCategoryByCategoryID(int categoryID)
        {
            try
            {
                CategoryResponseDTO categoryResponseDTO = await _categoryService.GetCategoryByCategoryID(categoryID);
                return Ok(categoryResponseDTO);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost, Route("AddNewCategory")]
        public async Task<ActionResult<CategoryRequestDTO>> AddNewCategory([FromBody] CategoryRequestDTO categoryRequestDTO)
        {
            try
            {
                await _categoryService.AddNewCategory(categoryRequestDTO);
                return Ok(categoryRequestDTO);
            }
            catch (Exception e)
            {
                return BadRequest(e.InnerException);
            }
        }

        [HttpPut, Route("UpdateCategory")]
        public async Task<ActionResult<CategoryRequestDTO>> UpdateCategory([FromBody] CategoryRequestDTO categoryRequestDTO)
        {
            try
            {
                await _categoryService.UpdateCategory(categoryRequestDTO);
                return Ok(categoryRequestDTO);
            }
            catch (Exception e)
            {
                return BadRequest(e.InnerException);
            }
        }

        [HttpDelete, Route("DeleteCategoryByCategoryID/{categoryID}")]
        public async Task<ActionResult> DeleteCategoryByCategoryID(int categoryID)
        {
            try
            {
                await _categoryService.DeleteCategoryByCategoryID(categoryID);
                return Ok($"Category with ID : {categoryID} deleted succesfully");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}

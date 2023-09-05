using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using SportsZoneWebAPI.Repositories;
using SportsZoneWebAPI.Models;
using SportsZoneWebAPI.DTOs;

namespace SportsZoneWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly CategoryRepository _categoryRepository;
        public CategoryController(CategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        [HttpGet, Route("GetAllCategories")]
        public async Task<ActionResult<IEnumerable<Category>>> GetAllCategories()
        {
            try
            {
                IEnumerable<Category> categories = await _categoryRepository.GetAllCategories();
                return Ok(categories);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpGet, Route("GetCategoryByCategoryID/{categoryID}")]
        public async Task<ActionResult<Category>> GetCategoryByCategoryID(int categoryID)
        {
            try
            {
                Category category = await _categoryRepository.GetCategoryByCategoryID(categoryID);
                return Ok(category);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost, Route("AddNewCategory")]
        public async Task<ActionResult<Category>> AddNewCategory([FromBody] Category category)
        {
            try
            {
                await _categoryRepository.AddNewCategory(category);
                return Ok(category);
            }
            catch (Exception e)
            {
                return BadRequest(e.InnerException);
            }
        }

        [HttpPut, Route("UpdateCategory")]
        public async Task<ActionResult<Category>> UpdateCategory([FromBody] Category category)
        {
            try
            {
                await _categoryRepository.UpdateCategory(category);
                return Ok(category);
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
                await _categoryRepository.DeleteCategoryByCategoryID(categoryID);
                return Ok($"Category with ID : {categoryID} deleted succesfully");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}

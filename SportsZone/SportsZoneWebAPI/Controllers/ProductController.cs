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
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        [HttpGet, Route("GetAllProducts")]
        public async Task<ActionResult<IEnumerable<ProductResponseDTO>>> GetAllProducts()
        {
            try
            {
                IEnumerable<ProductResponseDTO> productResponseDTOs = await _productService.GetAllProducts();
                return Ok(productResponseDTOs);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpGet, Route("GetAllProductByCategoryID/{categoryID}")]
        public async Task<ActionResult<IEnumerable<ProductResponseDTO>>> GetAllProductsByCategoryID(int categoryID)
        {
            try
            {
                IEnumerable<ProductResponseDTO> productResponseDTOs = await _productService.GetAllProductsByCategoryID(categoryID);
                return Ok(productResponseDTOs);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpGet, Route("GetProductByproductID/{productID}")]
        public async Task<ActionResult<ProductResponseDTO>> GetProductByproductID(int productID)
        {
            try
            {
                ProductResponseDTO productResponseDTO = await _productService.GetProductByproductID(productID);
                return Ok(productResponseDTO);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost, Route("AddNewProduct")]
        public async Task<ActionResult<ProductRequestDTO>> AddNewProduct([FromBody] ProductRequestDTO productRequestDTO)
        {
            try
            {
                await _productService.AddNewProduct(productRequestDTO);
                return Ok(productRequestDTO);
            }
            catch (Exception e)
            {
                return BadRequest(e.InnerException);
            }
        }

        [HttpPut, Route("UpdateProduct")]
        public async Task<ActionResult<ProductRequestDTO>> UpdateProduct([FromBody] ProductRequestDTO productRequestDTO)
        {
            try
            {
                await _productService.UpdateProduct(productRequestDTO);
                return Ok(productRequestDTO);
            }
            catch (Exception e)
            {
                return BadRequest(e.InnerException);
            }
        }
        [HttpDelete, Route("DeleteProductByProductID/{productID}")]
        public async Task<ActionResult> DeleteProductByProductID(int productID)
        {
            try
            {
                await _productService.DeleteProductByProductID(productID);
                return Ok($"Products with ID : {productID} deleted succesfully");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete, Route("DeleteAllProductsByCategoryID/{categoryID}")]
        public async Task<ActionResult> DeleteAllProductsByCategoryID(int categoryID)
        {
            try
            {
                await _productService.DeleteAllProductsByCategoryID(categoryID);
                return Ok($"Products with categoryID : {categoryID} deleted succesfully");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpDelete, Route("DeleteAllProducts")]
        public async Task<ActionResult> DeleteAllProducts()
        {
            try
            {
                await _productService.DeleteAllProducts();
                return Ok($"Products deleted succesfully");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}

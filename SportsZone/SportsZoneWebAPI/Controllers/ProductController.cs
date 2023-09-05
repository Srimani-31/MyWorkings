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
    public class ProductController : ControllerBase
    {
        private readonly ProductRepository _productRepository;
        public ProductController(ProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        [HttpGet, Route("GetAllProducts")]
        public async Task<ActionResult<IEnumerable<Product>>> GetAllProducts()
        {
            try
            {
                IEnumerable<Product> products = await _productRepository.GetAllProducts();
                return Ok(products);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpGet, Route("GetAllProductByCategoryID/{categoryID}")]
        public async Task<ActionResult<IEnumerable<Product>>> GetAllProductByCategoryID(int categoryID)
        {
            try
            {
                IEnumerable<Product> products = await _productRepository.GetAllProductsByCategoryID(categoryID);
                return Ok(products);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpGet, Route("GetProductByproductID/{productID}")]
        public async Task<ActionResult<Product>> GetProductByproductID(int productID)
        {
            try
            {
                Product product = await _productRepository.GetProductByProductID(productID);
                return Ok(product);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost, Route("AddNewProduct")]
        public async Task<ActionResult<Product>> AddNewProduct([FromBody] Product product)
        {
            try
            {
                await _productRepository.AddNewProduct(product);
                return Ok(product);
            }
            catch (Exception e)
            {
                return BadRequest(e.InnerException);
            }
        }

        [HttpPut, Route("UpdateProduct")]
        public async Task<ActionResult<Product>> UpdateProduct([FromBody] Product product)
        {
            try
            {
                await _productRepository.UpdateProduct(product);
                return Ok(product);
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
                await _productRepository.DeleteProductByProductID(productID);
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
                await _productRepository.DeleteAllProductsByCategoryID(categoryID);
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
                await _productRepository.DeleteAllProducts();
                return Ok($"Products deleted succesfully");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}

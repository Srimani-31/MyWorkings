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
//    public class ProductService 
//    {
//        private readonly ProductRepository _productRepository;
//        public ProductService(ProductRepository productRepository)
//        {
//            _productRepository = productRepository;
//        }
//        public async Task<IEnumerable<Product>> GetAllProducts()
//        {
//            try
//            {
//                IEnumerable<Product> products = await _productRepository.GetAllProducts();
//                return products;
//            }
//            catch (Exception)
//            {
//                throw;
//            }
//        }
//        public async Task<IEnumerable<Product>> GetAllProductByCategoryID(int categoryID)
//        {
//            try
//            {
//                IEnumerable<Product> products = await _productRepository.GetAllProductsByCategoryID(categoryID);
//                return products;
//            }
//            catch (Exception)
//            {
//                throw;
//            }
//        }
//        public async Task<Product> GetProductByproductID(int productID)
//        {
//            try
//            {
//                Product product = await _productRepository.GetProductByProductID(productID);
//                return product;
//            }
//            catch (Exception)
//            {
//                throw;
//            }
//        }

//        public async Task AddNewProduct(Product product)
//        {
//            try
//            {
//                await _productRepository.AddNewProduct(product);
//            }
//            catch (Exception)
//            {
//                throw;
//            }
//        }

//        public async Task UpdateProduct(Product product)
//        {
//            try
//            {
//                await _productRepository.UpdateProduct(product);
//            }
//            catch (Exception)
//            {
//                throw;
//            }
//        }
//        public async Task DeleteProductByProductID(int productID)
//        {
//            try
//            {
//                await _productRepository.DeleteProductByProductID(productID);
//            }
//            catch (Exception)
//            {
//                throw;
//            }
//        }

//        public async Task DeleteAllProductsByCategoryID(int categoryID)
//        {
//            try
//            {
//                await _productRepository.DeleteAllProductsByCategoryID(categoryID);
//            }
//            catch (Exception)
//            {
//                throw;
//            }
//        }
//        public async Task DeleteAllProducts()
//        {
//            try
//            {
//                await _productRepository.DeleteAllProducts();
//            }
//            catch (Exception)
//            {
//                throw;
//            }
//        }
//    }
//}

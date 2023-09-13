using AutoMapper;
using SportsZoneWebAPI.DTOs;
using SportsZoneWebAPI.Models;
using SportsZoneWebAPI.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SportsZoneWebAPI.Services.Interfaces;

namespace SportsZoneWebAPI.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }
        public async Task<bool> IsAvail(int productID)
        {
            try
            {
                return await _productRepository.IsAvail(productID);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<IEnumerable<ProductResponseDTO>> GetAllProducts()
        {
            try
            {
                IEnumerable<Product> products = await _productRepository.GetAllProducts();
                IList<ProductResponseDTO> productResponseDTOs = new List<ProductResponseDTO>();
                foreach (Product product in products)
                {
                    ProductResponseDTO productResponseDTO = _mapper.Map<ProductResponseDTO>(product);
                    productResponseDTOs.Add(productResponseDTO);
                }
                return productResponseDTOs;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<IEnumerable<ProductResponseDTO>> GetAllProductsByCategoryID(int categoryID)
        {
            try
            {
                IEnumerable<Product> products = await _productRepository.GetAllProductsByCategoryID(categoryID);
                IList<ProductResponseDTO> productResponseDTOs = new List<ProductResponseDTO>();
                foreach (Product product in products)
                {
                    ProductResponseDTO productResponseDTO = _mapper.Map<ProductResponseDTO>(product);
                    productResponseDTOs.Add(productResponseDTO);
                }
                return productResponseDTOs;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<ProductResponseDTO> GetProductByproductID(int productID)
        {
            try
            {
                Product product = await _productRepository.GetProductByProductID(productID);
                ProductResponseDTO productResponseDTO = _mapper.Map<ProductResponseDTO>(product);
                return productResponseDTO;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task AddNewProduct(ProductRequestDTO productRequestDTO)
        {
            try
            {
                Product product = _mapper.Map<Product>(productRequestDTO);
                product.CreatedBy = productRequestDTO.CreatedUpdatedBy;
                product.CreatedDate = DateTime.Now;

                await _productRepository.AddNewProduct(product);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task UpdateProduct(ProductRequestDTO productRequestDTO)
        {
            try
            {
                Product product = await _productRepository.GetProductByProductID(productRequestDTO.ProductID);
                _mapper.Map(productRequestDTO, product);

                await _productRepository.UpdateProduct(product);
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
                await _productRepository.DeleteProductByProductID(productID);
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
                await _productRepository.DeleteAllProductsByCategoryID(categoryID);
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
                await _productRepository.DeleteAllProducts();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}

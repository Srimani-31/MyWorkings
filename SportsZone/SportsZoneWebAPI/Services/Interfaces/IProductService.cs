using SportsZoneWebAPI.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SportsZoneWebAPI.Services.Interfaces
{
    public interface IProductService
    {
        public Task<bool> IsAvail(int productID);
        public Task<IEnumerable<ProductResponseDTO>> GetAllProducts();
        public Task<IEnumerable<ProductResponseDTO>> GetAllProductsByCategoryID(int categoryID);
        public Task<ProductResponseDTO> GetProductByproductID(int productID);
        public Task AddNewProduct(ProductRequestDTO productRequestDTO);
        public Task UpdateProduct(ProductRequestDTO productRequestDTO);
        public Task DeleteProductByProductID(int productID);
        public Task DeleteAllProductsByCategoryID(int categoryID);
        public Task DeleteAllProducts();
    }
}

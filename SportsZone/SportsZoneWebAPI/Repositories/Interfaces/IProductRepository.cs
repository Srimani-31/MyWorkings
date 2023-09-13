using SportsZoneWebAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SportsZoneWebAPI.Repositories.Interfaces
{
    public interface IProductRepository
    {
        public Task<IEnumerable<Product>> GetAllProducts();
        public Task<IEnumerable<Product>> GetAllProductsByCategoryID(int categoryID);
        public Task<Product> GetProductByProductID(int productID);
        public Task AddNewProduct(Product product);
        public Task UpdateProduct(Product product);
        public Task DeleteProductByProductID(int productID);
        public Task DeleteAllProductsByCategoryID(int categoryID);
        public Task DeleteAllProducts();
        public Task UpdateStockCount(int productID, int quantityPurchased, bool IsReturn = false);
    }
}

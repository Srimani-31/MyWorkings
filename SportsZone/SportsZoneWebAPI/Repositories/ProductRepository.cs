using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OfficeOpenXml;
using SportsZoneWebAPI.Data.Interfaces;
using SportsZoneWebAPI.Models;
using SportsZoneWebAPI.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsZoneWebAPI.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ISportsZoneDbContext _sportsZoneDbContext;
        private readonly IUtil _util;
        public ProductRepository(ISportsZoneDbContext sportsZoneDbContext, IUtil util)
        {
            _sportsZoneDbContext = sportsZoneDbContext;
            _util = util;
        }
        public async Task<bool> IsAvail(int productID)
        {
            try
            {
                return await _util.IsAvail(dbSet: _sportsZoneDbContext.Products, intID: productID);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            try
            {
                return await _sportsZoneDbContext.Products.ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<IEnumerable<Product>> GetAllProductsByCategoryID(int categoryID)
        {
            try
            {
                return await _sportsZoneDbContext.Products.Where(product => product.CategoryID == categoryID).ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Product> GetProductByProductID(int productID)
        {
            try
            {
                return await _sportsZoneDbContext.Products.FindAsync(productID);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task AddMultipleProducts(IFormFile file, string createdUpdatedBy)
        {
            try
            {
                using (var stream = file.OpenReadStream())
                {
                    using (var package = new ExcelPackage(stream))
                    {
                        ExcelWorksheet worksheet = package.Workbook.Worksheets.FirstOrDefault();

                        if (worksheet == null)
                        {
                            throw new BadRequestException("Excel file is empty or invalid.");
                        }

                        int rowCount = worksheet.Dimension.Rows;

                        var products = new List<Product>();

                        for (int row = 2; row <= rowCount; row++) // Assuming the first row is the header
                        {
                            Product product = new()
                            {
                                ProductName = worksheet.Cells[row, 1].Value?.ToString(),
                                ProductImage = worksheet.Cells[row, 2].Value?.ToString(),
                                StockCount = int.Parse(worksheet.Cells[row, 3].Value?.ToString() ?? "0"),
                                Price = decimal.Parse(worksheet.Cells[row, 4].Value?.ToString() ?? "0.00"),
                                CategoryID = int.Parse(worksheet.Cells[row, 4].Value?.ToString() ?? "0"),
                                CreatedBy = createdUpdatedBy,
                                CreatedDate = DateTime.Now,
                                UpdatedBy = createdUpdatedBy,
                                UpdatedDate = DateTime.Now
                            };

                            await AddNewProduct(product);
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task AddNewProduct(Product product)
        {
            try
            {
                _sportsZoneDbContext.Products.Add(product);
                await _sportsZoneDbContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task UpdateProduct(Product product)
        {
            try
            {
                _sportsZoneDbContext.Products.Update(product);
                await _sportsZoneDbContext.SaveChangesAsync();
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
                Product product = await _sportsZoneDbContext.Products.SingleOrDefaultAsync(product => product.CategoryID == productID);
                if (product != null)
                {
                    _sportsZoneDbContext.Products.Remove(product);
                }
                else
                {
                    throw new KeyNotFoundException("Category not found");
                }
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
                IEnumerable<Product> products = await GetAllProductsByCategoryID(categoryID);
                foreach (Product product in products)
                {
                    _sportsZoneDbContext.Products.Remove(product);
                }
                await _sportsZoneDbContext.SaveChangesAsync();

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
                //await _categoryRepository.DeleteAllCategories();
                await _sportsZoneDbContext.SaveChangesAsync();

            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task UpdateStockCount(int productID, int quantityPurchased, bool IsReturn = false)
        {
            try
            {
                Product product = await GetProductByProductID(productID);
                if (!IsReturn)
                    product.StockCount = product.StockCount - quantityPurchased;
                else
                    product.StockCount = product.StockCount + quantityPurchased;
                await UpdateProduct(product);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}

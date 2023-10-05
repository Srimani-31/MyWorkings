using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using SportsZoneWebAPI.Data.Interfaces;
using SportsZoneWebAPI.Models;
using SportsZoneWebAPI.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace SportsZoneWebAPI.Repositories
{
    public class CustomerRepository : ICustomerRespository
    {
        private readonly ISportsZoneDbContext _sportsZoneDbContext;
        private readonly IUtil _util;
        public CustomerRepository(ISportsZoneDbContext sportsZoneDbContext, IUtil util)
        {
            _sportsZoneDbContext = sportsZoneDbContext;
            _util = util;
        }

        public async Task<bool> IsAvail(string email)
        {
            try
            {
                return await _util.IsAvail(dbSet: _sportsZoneDbContext.Customers, stringID: email);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<IEnumerable<Customer>> GetAllCustomers()
        {
            try
            {
                return await _sportsZoneDbContext.Customers.ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<Customer> GetCustomerByCustomerID(string email)
        {
            try
            {
                Customer customer = await _sportsZoneDbContext.Customers.FindAsync(email);
                return customer;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task CreateCustomer(Customer customer, IFormFile image)
        {
            try
            {
                string imagePath = await StoreImage(image, customer.Email);
                customer.ProfilePhoto = imagePath;
                _sportsZoneDbContext.Customers.Add(customer);

                await _sportsZoneDbContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task UpdateCustomer(Customer customer)
        {
            try
            {
                _sportsZoneDbContext.Customers.Update(customer);
                await _sportsZoneDbContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task DeleteCustomerByCustomerID(string email)
        {
            try
            {
                Customer customer = await GetCustomerByCustomerID(email);

                if (customer != null)
                {
                    _sportsZoneDbContext.Customers.Remove(customer);
                    await _sportsZoneDbContext.SaveChangesAsync();
                }
                else
                {
                    throw new KeyNotFoundException("customer not found");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task DeleteAllCustomers()
        {
            try
            {
                IEnumerable<Customer> customers = await GetAllCustomers();
                foreach (Customer customer in customers)
                {
                    _sportsZoneDbContext.Customers.Remove(customer);
                }
                await _sportsZoneDbContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }
        private static async Task<string> StoreImage(IFormFile image, string email)
        {
            string uploadDirectory = Util.GetCustomerImagesDirectory();
            string filePath;
            if (image != null)
            {
                string fileExtension = Path.GetExtension(image.FileName).ToLower();

                //Ensure the file has a valid image file extension (e.g., .jpg, .png)
                if (IsImageFileExtensionValid(fileExtension))
                {
                    string imageFileName = email + Guid.NewGuid().ToString().Substring(0, 4) + fileExtension;

                    //Example: Saving the image to a file
                    filePath = Path.Combine(uploadDirectory, imageFileName);
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await image.CopyToAsync(stream);
                    }
                }
                else
                {
                    throw new BadRequestException("Invalid file format. Supported formats: .jpg, .png");
                }
            }
            else
            {
                string defaultImageFileName = "default.png";
                filePath = Path.Combine(uploadDirectory, defaultImageFileName);
            }

            return filePath;
        }
        private static bool IsImageFileExtensionValid(string fileExtension)
        {
            // Add valid image file extensions as needed
            return fileExtension == ".jpg" || fileExtension == ".jpeg" || fileExtension == ".png";
        }
        public FileStream GetImage(string imagePath)
        {

            // Check if the file exists
            if (File.Exists(imagePath))
            {
                var imageStream = new FileStream(imagePath, FileMode.Open, FileAccess.Read);
                return imageStream;
            }
            else
            {
                string defaultImage = @"D:\MyDocumentaries\xAI.png";
                var imageStream = new FileStream(defaultImage, FileMode.Open, FileAccess.Read);
                return imageStream;
                //return File(fileStream, "application/octet-stream", Path.GetFileName("D:\MyDocumentaries\xAI.png"));
            }

        }

        //public IActionResult GetImage(string imagePath)
        //{
        //    FileStream imageStream = null;

        //    // Check if the file exists
        //    if (File.Exists(imagePath))
        //    {
        //        imageStream = new FileStream(imagePath, FileMode.Open, FileAccess.Read);
        //    }
        //    else
        //    {
        //        string defaultImage = @"D:\MyDocumentaries\xAI.png";
        //        imageStream = new FileStream(defaultImage, FileMode.Open, FileAccess.Read);
        //    }

        //    if (imageStream != null)
        //    {
        //        return File(imageStream, "application/octet-stream", Path.GetFileName(imagePath));
        //    }
        //    else
        //    {
        //        return NotFound("File not found");
        //    }
        //}


    }
}

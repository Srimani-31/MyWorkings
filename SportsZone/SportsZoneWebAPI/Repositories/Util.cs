using Microsoft.EntityFrameworkCore;
using SportsZoneWebAPI.Data.Interfaces;
using SportsZoneWebAPI.Models;
using SportsZoneWebAPI.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsZoneWebAPI.Repositories
{
    public class Util : IUtil
    {
        private readonly ISportsZoneDbContext _sportsZoneDbContext;
        public Util(ISportsZoneDbContext sportsZoneDbContext)
        {
            _sportsZoneDbContext = sportsZoneDbContext;
        }
        // convert string to byte[] with hashed 
        public static byte[] HashItemToBytes(string password)
        {
            return Encoding.UTF8.GetBytes(BCrypt.Net.BCrypt.HashPassword(password));
        }

        //Hash any string value
        public static string HashItem(string item)
        {
            return BCrypt.Net.BCrypt.HashPassword(item);
        }

        public async Task<bool> IsAvail<TEntity>(DbSet<TEntity> dbSet,string stringID = null, int intID = 0) where TEntity : class
        {
            bool isAvail = false;
            if (!string.IsNullOrWhiteSpace(stringID))
            {
                if (await dbSet.FindAsync(stringID) != null)
                    isAvail = true;
            }
            else
            {
                if (await dbSet.FindAsync(intID) != null)
                    isAvail = true;
            }
            return isAvail;
        }

        public decimal CalculateTotalAmountByQuantity(int productID, int quantity)
        {
            try
            {
                decimal totalAmount = _sportsZoneDbContext.Products
                    .SingleOrDefault(product => product.ProductID == productID)
                    .Price * quantity;
                return totalAmount;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public decimal EvaluateCartTotal(int cartID)
        {
            try
            {
                decimal cartTotal = _sportsZoneDbContext.CartItems
                    .Where(cartItem => cartItem.CartID == cartID)
                    .Select(cartItem => cartItem.TotalPrice)
                    .Sum();
                return cartTotal;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public string GenerateOrderID()
        {
            try
            {
                //get timestamp
                DateTime currentDateTime = DateTime.Now;
                string formattedDateTime = currentDateTime.ToString("yyyyMMddHHmmss");

                //generate guid of 4 chars
                string guidPrefix = Guid.NewGuid().ToString("N").Substring(0, 4);

                //get last orderserailnumber and increament it
                string increament = GetOrderSerialNumber(_sportsZoneDbContext.Orders);

                string orderID = "SPRTZN-" + formattedDateTime + "-" + guidPrefix + "-" + increament;

                return orderID;
            }
            catch (Exception)
            {
                throw;
            }
        }
        private static string GetOrderSerialNumber(DbSet<Order> orders)
        {
            try
            {
                // Retrieve the last four digits of OrderID from the database
                IEnumerable<string> lastFourDigits = orders
                    .Select(order => order.OrderID.Substring(order.OrderID.Length - 4))
                    .ToList();

                // Parse the last four digits to integers
                IEnumerable<int> lastFourDigitsInt = lastFourDigits
                    .Select(str => int.TryParse(str, out int value) ? value : 0)
                    .ToList();

                // Calculate the maximum of the parsed integers
                int maxIncrement = lastFourDigitsInt.DefaultIfEmpty().Max();

                int increment = maxIncrement + 1;

                // Format the increment to have leading zeros and four digits
                string formattedIncrement = increment.ToString("D4");

                return formattedIncrement;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static bool VerifyPassword(byte[] hashedPassword, string enteredPassword)
        {
            // Convert the byte[] hashed password to a string
            string hashedPasswordString = Encoding.UTF8.GetString(hashedPassword);

            // Use BCrypt's Verify method to compare the entered password with the hashed password
            bool isPasswordMatch = BCrypt.Net.BCrypt.Verify(enteredPassword, hashedPasswordString);

            return isPasswordMatch;
        }
    }
}

using Microsoft.EntityFrameworkCore;
using SportsZoneWebAPI.Data.Interfaces;
using SportsZoneWebAPI.Models;
using SportsZoneWebAPI.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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

        //compare the input with stored hash
        public static bool IsValid(string userItem, string databaseItem)
        {
            return BCrypt.Net.BCrypt.Verify(userItem, databaseItem);
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
        public static bool IsEqual(string password, string hashedPassword)
        {
            return BCrypt.Net.BCrypt.Verify(password, hashedPassword);

        }
    }
}

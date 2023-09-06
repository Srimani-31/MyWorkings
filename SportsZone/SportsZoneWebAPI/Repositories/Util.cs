using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.Text;
using Microsoft.EntityFrameworkCore;
using SportsZoneWebAPI.Models;

namespace SportsZoneWebAPI.Repositories
{
    public class Util
    {
        private readonly SportsZoneDbContext _sportsZoneDbContext;
        public Util(SportsZoneDbContext sportsZoneDbContext)
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
                decimal cartTotal =  _sportsZoneDbContext.CartItems
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
                string increament = GetOrderSerialNumber(_sportsZoneDbContext.Orders).ToString();

                string orderID = "SPRTZN-" + formattedDateTime + "-" + guidPrefix + "-" + increament;

                return orderID;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static int GetOrderSerialNumber(DbSet<Order> orders)
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
                return increment;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.Text;
namespace SportsZoneWebAPI.Repositories
{
    public class Util
    {
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
    }
}

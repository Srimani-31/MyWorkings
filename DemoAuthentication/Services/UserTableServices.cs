using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using DemoAuthentication.Entities;
using BCryptNet = BCrypt.Net.BCrypt;

namespace DemoAuthentication.Services
{
    public class UserTableServices
    {
        private readonly MyDatabaseContext _context;
        public UserTableServices()
        {
            _context = new MyDatabaseContext();
        }
        // Password conversion stirng to bytes[]
        public static byte[] HashPasswordToBytes(string password)
        {
            return Encoding.UTF8.GetBytes(BCrypt.Net.BCrypt.HashPassword(password));
        }

        //Password conversion bytes[] to string
        public static string HashPasswordToString(byte[] password)
        {
            return Encoding.UTF8.GetString(password);
        }

        // During user registration
        public async void RegisterUser(UserTableHashPassword userTable)
        {

            // Hash the password with the salt
            byte[] hashPasswordInBytes = HashPasswordToBytes(userTable.Password);

            // Store the hashed password and salt in the database
            // ...
            UserTable user = new UserTable()
            {
                Id = userTable.Id,
                Name = userTable.Name,
                Email = userTable.Email,
                Password = hashPasswordInBytes
            };
            _context.Add(user);
            await _context.SaveChangesAsync();
        }

        // During user login
        public bool ValidateUserCredentials(string userId, string password)
        {
            UserTable user = _context.UserTables.SingleOrDefault(x => x.Id == userId);
            if(user != null)
            {
                if (BCryptNet.Verify(password,HashPasswordToString(user.Password)))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
            
        }
    }
}

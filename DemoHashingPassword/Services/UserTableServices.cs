using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using DemoHashingPassword.Models;

namespace DemoHashingPassword.Services
{

    public class UserTableServices
    {
        private readonly MyDatabaseContext _context;
        public UserTableServices()
        {
            _context = new MyDatabaseContext();
        }

        #region FOR REGISTRATION 
        //Register user
        public void RegisterUser(User user)
        {
            // Hash the password with the salt
            byte[] hashPasswordInBytes = HashPasswordToBytes(user.Password);

            // Store the hashed password and salt in the database
            // ...
            UserTable _user = new UserTable()
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,
                Password = hashPasswordInBytes
            };
            _context.Add(_user);
            _context.SaveChanges();
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

        

        #endregion

        #region  FOR LOGIN
        public bool IsAuthenticatedUser(LoginViewModel login)
        {
            UserTable user = _context.UserTables.SingleOrDefault(x => x.Id == login.Id);
            return IsByteEqual(HashPasswordToBytes(login.Password), user.Password);

        }
        public static bool IsByteEqual(byte[] userhash, byte[] DatabaseHash)
        {
            bool isEqual = true;
            for (int i = 0; i < userhash.Length; i++)
            {
                if (userhash[i] != DatabaseHash[i])
                    isEqual = false;
            }
            return isEqual;
        }
        #endregion




    }
}

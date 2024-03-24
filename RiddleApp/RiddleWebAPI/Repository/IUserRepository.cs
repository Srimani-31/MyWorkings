using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RiddleWebAPI.Models;
namespace RiddleWebAPI.Repository
{
    public interface IUserRepository
    {
        public Task<IEnumerable<User>> GetAllUserAsync();
        public Task<User> GetUserByUsernameAsync(string username);
        public Task AddUserAsync(User user);
        public Task UpdateUserAsync(User user);
        public Task DeleteUserAsync(string username);
        public Task<bool> AuthenticateUser(Login login);
        public string HashPassword(string password);
        public bool IsValidPassword(string password,string hashedPassword);
        public Task<bool> IsAvail(string username);

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RiddleWebAPI.Models;

namespace RiddleWebAPI.Repository
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAllUserAsync();
        Task<User> GetUserByUsernameAsync(string username);
        Task AddUserAsync(User user);
        Task UpdateUserAsync(User user);
        Task DeleteUserAsync(string username);

    }
}

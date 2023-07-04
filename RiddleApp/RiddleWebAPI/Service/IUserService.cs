using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RiddleWebAPI.Models;
using RiddleWebAPI.Dtos;

namespace RiddleWebAPI.Service
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetAllUserAsync();
        Task<User> GetUserByUsernameAsync(string username);
        Task AddUserAsync(UserDto userDto);
        Task UpdateUserAsync(UserDto userDto);
        Task DeleteUserAsync(string username);
    }
}

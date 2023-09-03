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
        public Task<IEnumerable<UserDto>> GetAllUserAsync();
        public Task<UserDto> GetUserByUsernameAsync(string username);
        public Task AddUserAsync(UserDto userDto);
        public Task UpdateUserAsync(UserDto userDto);
        public Task DeleteUserAsync(string username);
        public Task<bool> AuthenticateUser(LoginDto loginDto);
    }
}

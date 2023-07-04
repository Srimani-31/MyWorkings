using RiddleWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RiddleWebAPI.Repository;

namespace RiddleWebAPI.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task AddUserAsync(User user)
        {
            try
            {
                await _userRepository.AddUserAsync(user);
            }
            catch(Exception)
            {
                throw;
            }
        }

        public async Task DeleteUserAsync(string username)
        {
            try 
            {
                await _userRepository.DeleteUserAsync(username);
            }
            catch(Exception)
            {
                throw;
            }

        }

        public  async Task<IEnumerable<User>> GetAllUserAsync()
        {
            try
            {
                return await _userRepository.GetAllUserAsync();
            }
            catch(Exception)
            {
                throw;
            }
            
        }

        public async Task<User> GetUserByUsernameAsync(string username)
        {
            try
            {
                return await _userRepository.GetUserByUsernameAsync(username);
            }
            catch(Exception)
            {
                throw;
            }

        }

        public async Task UpdateUserAsync(User user)
        {
            try
            {
                await _userRepository.UpdateUserAsync(user);
            }
            catch(NullReferenceException)
            {
                throw;
            }
            catch(Exception)
            {
                throw;
            }
            
        }
    }
}

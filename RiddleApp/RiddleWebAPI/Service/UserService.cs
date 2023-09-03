using RiddleWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RiddleWebAPI.Repository;
using RiddleWebAPI.Dtos;
using AutoMapper;

namespace RiddleWebAPI.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public UserService(IUserRepository userRepository,IMapper mapper)
        {
            _mapper = mapper;
            _userRepository = userRepository;
        }
        public async Task AddUserAsync(UserDto userDto)
        {
            try
            {
                User user = _mapper.Map<User>(userDto);
                await _userRepository.AddUserAsync(user);
            }
            catch (Exception)
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
            catch (Exception)
            {
                throw;
            }

        }

        public async Task<IEnumerable<UserDto>> GetAllUserAsync()
        {
            try
            {
                IEnumerable<User> users = await _userRepository.GetAllUserAsync();
                IEnumerable<UserDto> userDtos = _mapper.Map<IEnumerable<UserDto>>(users);
                return userDtos;
            }
            catch (Exception)
            {
                throw;
            }

        }

        public async Task<UserDto> GetUserByUsernameAsync(string username)
        {
            try
            {
                User user = await _userRepository.GetUserByUsernameAsync(username);
                UserDto userDto = _mapper.Map<UserDto>(user);
                return userDto;
            }
            catch (Exception)
            {
                throw;
            }

        }

        public async Task UpdateUserAsync(UserDto userDto)
        {
            try
            {
                User user = _mapper.Map<User>(userDto);
                await _userRepository.UpdateUserAsync(user);
            }
            catch (NullReferenceException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }

        }

        public async Task<bool> AuthenticateUser(LoginDto loginDto)
        { 

            Login login = _mapper.Map<Login>(loginDto);
            return await _userRepository.AuthenticateUser(login);
        }
    }
}

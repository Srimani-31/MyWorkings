using Microsoft.EntityFrameworkCore;
using RiddleWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace RiddleWebAPI.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly MyRiddleDatabaseContext _dbContext;
        public UserRepository(MyRiddleDatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<bool> IsAvail(string username)
        {
            try
            {
                var user = await _dbContext.Users.SingleOrDefaultAsync(x => x.Username == username);
                if (user != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<User>> GetAllUserAsync()
        {
            try
            {
                return await _dbContext.Users.ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<User> GetUserByUsernameAsync(string username)
        {
            try
            {
                return await _dbContext.Users.FindAsync(username);
            }
            catch (Exception)
            {
                throw new Exception("An error occured while retrieving the data");
            }

        }
        public async Task AddUserAsync(User user)
        {
            try
            {
                user.Password = HashPassword(user.Password);
                _dbContext.Users.Add(user);
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }

        }
        public async Task UpdateUserAsync(User user)
        {
            try
            {
                var existingUser = await GetUserByUsernameAsync(user.Username);
                _dbContext.Entry(existingUser).State = EntityState.Detached;
                user.Password = HashPassword(user.Password);

                //existingUser.Username = user.Username;
                //existingUser.FullName = user.FullName;
                //existingUser.Email = user.Email;
                //existingUser.Password = HashPassword(user.Password);

                //_dbContext.Entry(existingUser).State = EntityState.Modified;

                _dbContext.Users.Update(user);
                await _dbContext.SaveChangesAsync();

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
                User user = await _dbContext.Users.SingleOrDefaultAsync(x => x.Username == username);

                if (user != null)
                {
                    _dbContext.Users.Remove(user);
                    await _dbContext.SaveChangesAsync();
                }
                else
                {
                    throw new KeyNotFoundException("User not found");
                }

            }
            catch (InvalidOperationException)
            {
                throw;
            }
            catch (KeyNotFoundException)
            {
                throw;
            }
            catch (Exception)
            {
                throw new Exception("An error occured while retrieving the data");
            }

        }
        public async Task<bool> AuthenticateUser(Login login)
        {
            User user = await _dbContext.Users.SingleOrDefaultAsync(x => x.Username == login.Username);
            if (user != null)
            {
                return IsValidPassword(login.Password, user.Password);
            }
            return false;
        }
        public string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }
        public bool IsValidPassword(string password, string hashedPassword)
        {
            return BCrypt.Net.BCrypt.Verify(password, hashedPassword);

        }


    }
}

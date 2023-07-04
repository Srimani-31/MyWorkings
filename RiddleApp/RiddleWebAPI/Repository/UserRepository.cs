using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RiddleWebAPI.Models;

namespace RiddleWebAPI.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly MyRiddleDatabaseContext _dbContext;
        public UserRepository(MyRiddleDatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }
        
        public async Task<IEnumerable<User>> GetAllUserAsync()
        {
            try
            {
                return await _dbContext.Users.ToListAsync();
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
                return await _dbContext.Users.FindAsync(username);
            }
            catch(Exception)
            {
                throw new Exception("An error occured while retrieving the data");
            }
            
        }
        public async Task AddUserAsync(User user)
        {
            try
            {
                _dbContext.Users.Add(user);
                await _dbContext.SaveChangesAsync();
            }
            catch(Exception)
            {
                throw new Exception("An error occured while adding the data");
            }

        }
        public async Task UpdateUserAsync(User user)
        {
            try
            {
                //User _user = await _dbContext.Users.SingleOrDefaultAsync(x => x.Username == user.Username);
                //if (_user == null)
                //    throw new Exception();
                //else
                //{
                    _dbContext.Entry(user).State = EntityState.Modified;//updating via property
                    //_dbContext.Users.Update(user); //updating via method
                    await _dbContext.SaveChangesAsync();
                //}
               
            }
            //catch(DbUpdateConcurrencyException)
            //{
            //    throw new DbUpdateConcurrencyException("Concurrency conflit");
            //}
            //catch (NullReferenceException)
            //{
            //    throw new NullReferenceException("Object reference not set to an instance of an object");
            //}
            //catch (KeyNotFoundException)
            //{
            //    throw;
            //}
            catch(Exception)
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
            catch(InvalidOperationException)
            {
                throw;
            }
            catch (KeyNotFoundException)
            {
                throw;
            }
            catch(Exception)
            {
                throw new Exception("An error occured while retrieving the data");
            }

        }


    }
}

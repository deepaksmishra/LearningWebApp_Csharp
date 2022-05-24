using LWAJWTLOG.Interface;
using LWAJWTLOG.Model;
using LWAJWTLOG.Models;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace LWAJWTLOG.Repository
{
    
    
        public class UserRegistrationRepository : IUserRegistrations
        {
            readonly DatabaseContext _dbContext = new();

            public UserRegistrationRepository(DatabaseContext dbContext)
            {
                _dbContext = dbContext;
            }

            public List<UserRegistration> GetUserRegistrationDetails()
            {
                try
                {
                    return _dbContext.UserRegistrations.ToList();
                }
                catch
                {
                    throw;
                }
            }

            public UserRegistration GetUserRegistrationDetails(int id)
            {
                try
                {
                    UserRegistration? UserRegistration = _dbContext.UserRegistrations.Find(id);
                    if (UserRegistration != null)
                    {
                        return UserRegistration;
                    }
                    else
                    {
                    throw new DataException("Your Entered ID Doesn't Match Any value in our database please check the value");
                }
            }
                catch
                {
               // loggerx.Debug("Not FOUND");
                throw new DataException("Your Entered ID Doesn't Match Any value in our database please check the value"); ;
                }
            }

            public void AddUserRegistration(UserRegistration UserRegistration)
            {
                try
                {
                    _dbContext.UserRegistrations.Add(UserRegistration);
                    _dbContext.SaveChanges();
                }
                catch
                {
                    throw;
                }
            }

            public void UpdateUserRegistration(UserRegistration UserRegistration)
            {
                try
                {
                    _dbContext.Entry(UserRegistration).State = EntityState.Modified;
                    _dbContext.SaveChanges();
                }
                catch
                {
                    throw;
                }
            }

            public UserRegistration DeleteUserRegistration(int id)
            {
                try
                {

                    UserRegistration? UserRegistration = _dbContext.UserRegistrations.Find(id);

                    if (UserRegistration != null)
                    {
                        _dbContext.UserRegistrations.Remove(UserRegistration);
                        _dbContext.SaveChanges();
                        return UserRegistration;
                    }
                    else
                    {
                    throw new Exception("Failed to retrieve something");
                }
            
                }
                catch
                {
                    throw;
                }
            }

            public bool CheckUserRegistration(int id)
            {
                return _dbContext.UserRegistrations.Any(e => e.id == id);
            }
        }
    }


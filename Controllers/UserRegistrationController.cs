using LWAJWTLOG.Interface;
using LWAJWTLOG.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NLog;
using System.Reflection;



namespace LWAJWTLOG.Controllers
{
    
   [Route("api/[controller]")]
    [ApiController]
    public class UserRegistrationController : ControllerBase
    {
        
        Logger loggerx = LogManager.GetCurrentClassLogger();
        

        private readonly IUserRegistrations _IUserRegistration;

        public UserRegistrationController(IUserRegistrations IUserRegistration)
        {
            _IUserRegistration = IUserRegistration;
        }

        // GET: api/employee>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserRegistration>>> Get()
        {
            loggerx.Debug("Userregistration API Loaded");
            return await Task.FromResult(_IUserRegistration.GetUserRegistrationDetails());
        }

        // GET api/employee/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserRegistration>> Get(int id)
        {
            var userRegistration  = await Task.FromResult(_IUserRegistration.GetUserRegistrationDetails(id));
            try
            {
                if (userRegistration == null)
                {
                    return NotFound("User not found in database");
                }
                return userRegistration;
            }
            catch (Exception ex)
            {
                loggerx.ErrorException("Error occured in Login controller", ex);
                //logger.Error(ex);  
            }
            return userRegistration;



        }





        // POST api/employee
        [HttpPost]
        public async Task<ActionResult<UserRegistration>> Post(UserRegistration UserRegistration)
        {
            _IUserRegistration.AddUserRegistration(UserRegistration);
            return await Task.FromResult(UserRegistration);
        }

        // PUT api/employee/5
        [HttpPut("{id}")]
        public async Task<ActionResult<UserRegistration>> Put(int id, UserRegistration UserRegistration)
        {
            if (id != UserRegistration.id)
            {
                return BadRequest();
            }
            try
            {
                _IUserRegistration.UpdateUserRegistration(UserRegistration);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserRegistrationExists(id))
                {
                    throw new Exception("Id already exixts please enter another id . it should be unique");

                    //return NotFound();
                }
                else
                {
                    throw new Exception("This is custom Exception handled globally");
                }
            }
            return await Task.FromResult(UserRegistration);
        }

        // DELETE api/employee/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<UserRegistration>> Delete(int id)
        {
            var userRegistration  = _IUserRegistration.DeleteUserRegistration(id);
            return await Task.FromResult(userRegistration);
        }

        private bool UserRegistrationExists(int id)
        {
            return _IUserRegistration.CheckUserRegistration(id);
        }
    }
}

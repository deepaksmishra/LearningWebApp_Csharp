using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using LWAJWTLOG.Model;
using LWAJWTLOG.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using NLog;

namespace LWAJWTLOG.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
  

        public class LoginController : ControllerBase
        {
        Logger loggerx = LogManager.GetCurrentClassLogger();
        public IConfiguration _configuration;
            private readonly DatabaseContext _context;

            public LoginController(IConfiguration config, DatabaseContext context)
            {
                _configuration = config;
                _context = context;
            }

            [HttpPost]
            public async Task<IActionResult> Post(Login _userData)
            {
            loggerx.Info("Login Post Controller Loaded");
            //loggerx.Error("test error");
                if (_userData != null && _userData.Username != null && _userData.password != null)
                {
                    var user = await GetUser(_userData.Username, _userData.password);

                    if (user != null)
                    {
                        //create claims details based on the user information
                        var claims = new[] {
                        new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                        
                        new Claim("Username", user.UserName),
                        new Claim("password", user.Password)
                    };

                        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
                        var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                        var token = new JwtSecurityToken(
                            _configuration["Jwt:Issuer"],
                            _configuration["Jwt:Audience"],
                            claims,
                            expires: DateTime.UtcNow.AddMinutes(10),
                            signingCredentials: signIn);

                        return Ok(new JwtSecurityTokenHandler().WriteToken(token));
                    }
                    else
                    {
                    loggerx.Error("Data not found error ");

                    return BadRequest("Invalid credentials");
                    }
                }
                else
                {
                    return BadRequest();
                }
            }

            private async Task<UserInfo> GetUser(string Username, string password)
            {
                return await _context.UserInfos.FirstOrDefaultAsync(u => u.UserName == Username && u.Password == password);
            }
        }
    }




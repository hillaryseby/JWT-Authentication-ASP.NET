using BCrypt.Net;
using JWTAuthentication.Constants;
using JWTAuthentication.DataTransferObjects;
using JWTAuthentication.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace JWTAuthentication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : Controller
    {
        public  static User newUser = new User();
        private IConfiguration configuration;

        public AuthController(IConfiguration _configure)
        {
            configuration = _configure;
        }
        
        [HttpPost("UserRegister")]
        public  ActionResult<User> userRegistration(UserDto user)
        {
            var newPasswordHash = BCrypt.Net.BCrypt.HashPassword(user.password);

            newUser.UserName = user.UserName;
            newUser.PasswordHash = newPasswordHash;
            

           return Ok(newUser);
        }

        [HttpPost("UserLogin")]
        public ActionResult<User> userLogin(UserDto user)
        {
            

            if(newUser.UserName != user.UserName)
            {
                return BadRequest("UserName is incorrect");
            }

            if(!BCrypt.Net.BCrypt.Verify(user.password, newUser.PasswordHash))
            {
                return BadRequest("Password is Incorrect");
            }

            var token = CreateToken(newUser);
            return Ok(token);
        }

        private string CreateToken(User user)
        {
           
            List<Claim> clain = new List<Claim>() {
          new Claim(ClaimTypes.Name , user.UserName),
          new Claim(ClaimTypes.Role, "Admin"),
          new Claim(ClaimTypes.Role, "user")
          };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
                configuration.GetSection("Jwt:Token").Value!));

            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
            var token = new JwtSecurityToken(
                claims: clain,
                expires: DateTime.UtcNow.AddDays(1),
                signingCredentials: credentials
                );

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);
            return jwt;
        }

    }
}

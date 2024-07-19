using Application.Dtos.User;
using Domain.Authentication;
using Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;

namespace API.Controllers
{
    public class AuthController(DatingAppDbContext context): BaseApiController
    {
        [HttpPost("Register")]
        public async Task<ActionResult<User>> Register(UserRegisterDto userRegisterDto)
        {
            var userExists = await context
                .Users
                .FirstOrDefaultAsync(x => x.UserName == userRegisterDto.UserName.ToLower());

            if (userExists is not null) 
                return Unauthorized("That user name already exists");

            using var hmac = new HMACSHA512();

            User newUser = new User
            {
                UserName = userRegisterDto.UserName.ToLower(),
                FirstName = userRegisterDto.FirstName,
                LastName = userRegisterDto.LastName,
                FullName = userRegisterDto.FirstName + " " + userRegisterDto.LastName,
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(userRegisterDto.Password)),
                PasswordSalt = hmac.Key
            };

            context.Users.Add(newUser);
            await context.SaveChangesAsync();
            return Ok(newUser);
        }

        [HttpPost("Login")]
        public async Task<ActionResult<User>> Login(UserLoginDto userLoginDto)
        {
            var userExists = await context
                .Users
                .FirstOrDefaultAsync(x => x.UserName == userLoginDto.UserName.ToLower());

            if (userExists is null)
                return Unauthorized("Invalid username");

            using var hmac = new HMACSHA512(userExists.PasswordSalt);

            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(userLoginDto.Password));

            for (int i = 0; i < computedHash.Length; i++) 
            {
                if(computedHash[i] != userExists.PasswordHash[i])
                    return Unauthorized("Invalid password");
            }

            return Ok(userExists);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using API.Data;
using API.DTOs;
using API.Entities;
using API.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    public class AccountController : BaseApiController
    {
        private readonly DataContext _context;
        private readonly ITokenService _tokenService;
        public AccountController(DataContext context, ITokenService tokenService)
        {
            this._tokenService = tokenService;
            this._context = context;
        }


        [HttpPost("register")]//RegisterDto password variable is string unlike pw variable in AppUser, and it can be used to to assign value to PassWordHash
        public async Task<ActionResult<UserDto>> Register(RegisterDto register)//with ActionResult you can return different HTTP status codes (BadRequest - 400) 
        {
            if (await UserExists(register.Username)) return BadRequest("Username is taken.");

            using var hmac = new HMACSHA512();

            var user = new AppUser//new user is created with the RegisterDto
            {
                UserName = register.Username.ToLower(),
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(register.Password)),//password variable in DTO is a string
                PasswordSalt = hmac.Key
            };

            _context.Users.Add(user);//user is added to the database
            await _context.SaveChangesAsync();//saves changes to the database

            return new UserDto
            {
                Username = user.UserName,
                Token = _tokenService.CreateToken(user)
            };
        }

        [HttpPost("login")]
        public async Task<ActionResult<UserDto>> Login(LoginDto login)
        {
            var user = await _context.Users.Include(p => p.Photos).SingleOrDefaultAsync(x => x.UserName == login.Username);

            if (user == null) return Unauthorized("Invalid username.");

            using var hmac = new HMACSHA512(user.PasswordSalt);
            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(login.Password));

            for (int i = 0; i < computedHash.Length; i++)
            {
                if (computedHash[i] != user.PasswordHash[i]) return Unauthorized("Invalid password.");
            }
            return new UserDto
            {
                Username = user.UserName,
                Token = _tokenService.CreateToken(user),
                PhotoUrl = user.Photos.FirstOrDefault(x => x.IsMain)?.Url
            };
        }

        private async Task<bool> UserExists(string username)
        {
            return await _context.Users.AnyAsync(x => x.UserName == username.ToLower());
        }
    }
}
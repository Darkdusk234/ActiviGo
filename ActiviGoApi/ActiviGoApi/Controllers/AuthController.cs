using ActiviGoApi.Core.Models;
using ActiviGoApi.Services.DTOs.AuthorizationDTOs;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ActiviGoApi.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<User> _users;
        private readonly IConfiguration _config;
        private readonly IValidator<RegisterDTO> _registerValidator;

        public AuthController(UserManager<User> users, IConfiguration config, IValidator<RegisterDTO> registerValidator)
        {
            _users = users;
            _config = config;
            _registerValidator = registerValidator;
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterDTO dto)
        {
            var validationResult = await _registerValidator.ValidateAsync(dto);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            var user = new User
            {
                UserName = dto.UserName,
                Email = dto.Email,
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                DateOfBirth = dto.DateOfBirth,
                Address = dto.Adress
            };

            var result = await _users.CreateAsync(user, dto.Password);

            if(!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }

            return Ok();
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto dto)
        {
            var user = await _users.FindByNameAsync(dto.UserName);

            if (user == null || !await _users.CheckPasswordAsync(user, dto.Password))
            {
                return Unauthorized("Invalid username or password.");
            }

            if(user.IsSuspended)
            {
                return Unauthorized("User is suspended.");
            }

            var token = await GenerateJwtTokenAsync(user);
            return Ok(new { Token = token });
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public async Task<IActionResult> SuspendUser(string id)
        {
            var user = await _users.FindByIdAsync(id);

            if (user == null)
            {
                return NotFound("User not found.");
            }

            if (user.IsSuspended)
            {
                return BadRequest("User already suspended");
            }

            user.IsSuspended = true;
            await _users.UpdateAsync(user);
            return Ok();
        }

        private async Task<string> GenerateJwtTokenAsync(User user)
        {
            var jwt = _config.GetSection("Jwt");
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwt["Key"]!));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var roles = await _users.GetRolesAsync(user);           // <-- fetch roles
            var roleClaims = roles.Select(r => new Claim(ClaimTypes.Role, r));

            var claims = new List<Claim>
             {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName!),
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };
            claims.AddRange(roleClaims);

            var token = new JwtSecurityToken(
                issuer: jwt["Issuer"],
                audience: jwt["Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(double.Parse(jwt["ExpiresInMinutes"]!)),
                signingCredentials: creds
            );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}

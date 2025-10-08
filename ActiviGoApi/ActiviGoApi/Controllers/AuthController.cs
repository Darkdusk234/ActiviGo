using ActiviGoApi.Core.Models;
using ActiviGoApi.Services.DTOs.AuthorizationDTOs;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

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
    }
}

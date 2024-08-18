using FitnessPalAPI.Models;
using FitnessPalAPI.Models.DataTransferModels.AuthTransferModels;
using FitnessPalAPI.Services.AuthServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Globalization;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace FitnessPalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;


        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterModel model)
        {
            var userExists = await _authService.UserExistsByEmailAsync(model.Email);
            if (userExists)
            {
                return BadRequest("User already exists");
            }

            var result = await _authService.RegisterUserAsync(model);

            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }

            return Ok("User registered successfully");
        }


        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            var authResponse = await _authService.AuthenticateUserAsync(model);
            if (authResponse == null)
            {
                return Unauthorized("Invalid username or password");
            }

            return Ok(authResponse);
        }

    }
}

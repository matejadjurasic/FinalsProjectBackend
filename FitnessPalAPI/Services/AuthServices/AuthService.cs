using FitnessPalAPI.Models.DatabaseModels;
using FitnessPalAPI.Models.DataTransferModels.AuthTransferModels;
using FitnessPalAPI.Services.TokenServices;
using Microsoft.AspNetCore.Identity;
using System.Diagnostics;
using System.Net;

namespace FitnessPalAPI.Services.AuthServices
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<User> _userManager;
        private readonly ITokenService _tokenService;

        public AuthService(UserManager<User> userManager, ITokenService tokenService)
        {
            _userManager = userManager;
            _tokenService = tokenService;
        }

        public async Task<AuthResponse?> AuthenticateUserAsync(LoginModel loginModel)
        {
            var user = await _userManager.FindByNameAsync(loginModel.Username);
            if (user != null && await _userManager.CheckPasswordAsync(user, loginModel.Password))
            {
                var token = _tokenService.GenerateToken(user);

                return new AuthResponse
                {
                    Id = user.Id,
                    Username = user.UserName,
                    Email = user.Email,
                    Name = user.Name,
                    Height = user.Height,
                    Weight = user.Weight,
                    Age = user.Age,
                    Gender = user.Gender,
                    Token = token,
                };
            }
            return null;
        }

        public async Task<bool> UserExistsByEmailAsync(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            return user != null;
        }

        public async Task<IdentityResult> RegisterUserAsync(RegisterModel model)
        {
            var user = new User
            {
                UserName = model.Username,
                Email = model.Email,
                Name = model.Name,
                Height = model.Height,
                Weight = model.Weight,
                Age = model.Age,
                Gender = model.Gender
            };

            return await _userManager.CreateAsync(user, model.Password);
        }
    }
}

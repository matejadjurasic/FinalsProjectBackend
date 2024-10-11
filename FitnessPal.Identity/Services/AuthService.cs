using FitnessPal.Application.Contracts.Infrastructure;
using FitnessPal.Application.Exceptions;
using FitnessPal.Application.Models.Identity;
using FitnessPal.Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessPal.Identity.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<User> _userManager;
        private readonly JwtSettings _jwtSettings;
        private readonly ITokenService _tokenService;

        public AuthService(UserManager<User> userManager,IOptions<JwtSettings> jwtSettings, ITokenService tokenService)
        {
            _userManager = userManager;
            _jwtSettings = jwtSettings.Value;
            _tokenService = tokenService;
        }

        public async Task<AuthResponse> Login(AuthRequest request)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);
            if(user != null && await _userManager.CheckPasswordAsync(user, request.Password))
            {
                var roles = await _userManager.GetRolesAsync(user);
                var token = await _tokenService.GenerateToken(user);

                return new AuthResponse
                {
                    Id = user.Id,
                    Name = user.Name,
                    Email = user.Email!,
                    Weight = user.Weight,
                    Height = user.Height,
                    Age = user.Age,
                    Gender = user.Gender,
                    Username = user.UserName!,
                    Token = token,
                    Roles = roles.ToList()
                };
            }
            throw new AuthenticationException("Ivalid Credentials");
        }

        public Task Register(RegistrationRequest request)
        {
            throw new NotImplementedException();
        }
    }
}

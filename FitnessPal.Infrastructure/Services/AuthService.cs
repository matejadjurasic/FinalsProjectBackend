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

namespace FitnessPal.Infrastructure.Services
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

        public async Task Register(RegistrationRequest request)
        {
            var userExists = await _userManager.FindByEmailAsync(request.Email);
            if (userExists != null)
            {
                throw new DuplicateEmailException("A user with this email already exists.");
            }

            var user = new User
            {
                UserName = request.Username,
                Email = request.Email,
                Name = request.Name,
                Height = request.Height,
                Weight = request.Weight,
                Age = request.Age,
                Gender = request.Gender
            };

            var result = await _userManager.CreateAsync(user, request.Password);
            if (!result.Succeeded)
            {
                throw new RegistrationException("Registration failed due to: " + string.Join(", ", result.Errors.Select(e => e.Description)));
            }

            var result2 = await _userManager.AddToRoleAsync(user, "Client");
            if (!result2.Succeeded)
            {
                throw new RegistrationException("Registration failed due to: " + string.Join(", ", result.Errors.Select(e => e.Description)));
            }

        }
    }
}

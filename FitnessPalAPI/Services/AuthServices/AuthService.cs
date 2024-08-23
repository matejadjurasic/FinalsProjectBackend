using AutoMapper;
using FitnessPalAPI.Exceptions;
using FitnessPalAPI.Models.DatabaseModels;
using FitnessPalAPI.Models.DataTransferModels.AuthTransferModels;
using FitnessPalAPI.Models.DataTransferModels.UserTransferModels;
using FitnessPalAPI.Services.GoalServices;
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
        private readonly IGoalService _goalService;
        private readonly IMapper _mapper;

        public AuthService(UserManager<User> userManager, ITokenService tokenService, IGoalService goalService, IMapper mapper)
        {
            _userManager = userManager;
            _tokenService = tokenService;
            _goalService = goalService;
            _mapper = mapper;
        }

        public async Task<AuthResponse> AuthenticateUserAsync(LoginModel loginModel)
        {
            var user = await _userManager.FindByNameAsync(loginModel.Username);
            if (user != null && await _userManager.CheckPasswordAsync(user, loginModel.Password))
            {
                var token = _tokenService.GenerateToken(user);

                return new AuthResponse
                {
                    Id = user.Id,
                    Username = user.UserName ?? string.Empty,
                    Email = user.Email ?? string.Empty,
                    Name = user.Name,
                    Height = user.Height,
                    Weight = user.Weight,
                    Age = user.Age,
                    Gender = user.Gender,
                    Token = token,
                };
            }
            throw new AuthenticationException("Invalid username or password");
        }

        public async Task RegisterUserAsync(RegisterModel model)
        {
            var userExists = await _userManager.FindByEmailAsync(model.Email);
            if (userExists != null)
            {
                throw new DuplicateEmailException("A user with this email already exists.");
            }

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

            var result = await _userManager.CreateAsync(user, model.Password);
            if (!result.Succeeded)
            {
                throw new RegistrationException("Registration failed due to: " + string.Join(", ", result.Errors.Select(e => e.Description)));
            }

            var userRead = _mapper.Map<UserReadDto>(user);

            //await _goalService(userRead, model.GoalType);
        }
    }
}

using FitnessPalAPI.Models.DataTransferModels.AuthTransferModels;
using Microsoft.AspNetCore.Identity;

namespace FitnessPalAPI.Services.AuthServices
{
    public interface IAuthService
    {
        Task<AuthResponse> AuthenticateUserAsync(LoginModel loginModel);
        Task RegisterUserAsync(RegisterModel model);
    }
}

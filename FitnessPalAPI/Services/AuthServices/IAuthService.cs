using FitnessPalAPI.Models.DataTransferModels.AuthTransferModels;
using Microsoft.AspNetCore.Identity;

namespace FitnessPalAPI.Services.AuthServices
{
    public interface IAuthService
    {
        Task<AuthResponse?> AuthenticateUserAsync(LoginModel loginModel);
        Task<IdentityResult> RegisterUserAsync(RegisterModel model);
        Task<bool> UserExistsByEmailAsync(string email);
    }
}

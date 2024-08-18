using FitnessPalAPI.Models.DatabaseModels;

namespace FitnessPalAPI.Services.TokenServices
{
    public interface ITokenService
    {
        string GenerateToken(User user);
    }
}

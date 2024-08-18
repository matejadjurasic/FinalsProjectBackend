using FitnessPalAPI.Models.DatabaseModels;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace FitnessPalAPI.Services.UserServices
{
    public interface IUserRepository
    {
        Task<User> GetByIdAsync(int userId);
        Task<IEnumerable<User>> GetAllAsync();
        Task<IdentityResult> AddAsync(User user, string password);
        Task<IdentityResult> UpdateAsync(User user);
        Task<IdentityResult> DeleteAsync(int userId);
    }
}

using FitnessPalAPI.Models.DataTransferModels.UserTransferModels;
using Microsoft.AspNetCore.Identity;

namespace FitnessPalAPI.Services.UserServices
{
    public interface IUserService
    {
        Task<IEnumerable<UserReadDto>> GetAllUsersAsync();
        Task<UserReadDto> GetUserByIdAsync(int userId);
        Task<UserReadDto> CreateUserAsync(UserCreateDto userDto);
        Task<UserReadDto> UpdateUserAsync(int userId, UserUpdateDto userDto);
        Task DeleteUserAsync(int userId);
    }
}

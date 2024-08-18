using FitnessPalAPI.Models.DataTransferModels.UserTransferModels;
using Microsoft.AspNetCore.Identity;

namespace FitnessPalAPI.Services.UserServices
{
    public interface IUserService
    {
        /// <summary>
        /// Retrieves all users from the database.
        /// </summary>
        /// <returns>A collection of user read DTOs.</returns>
        Task<IEnumerable<UserReadDto>> GetAllUsersAsync();

        /// <summary>
        /// Retrieves a single user by their ID.
        /// </summary>
        /// <param name="userId">The ID of the user to retrieve.</param>
        /// <returns>A user read DTO if found; otherwise, null.</returns>
        Task<UserReadDto> GetUserByIdAsync(int userId);

        /// <summary>
        /// Creates a new user based on the provided user creation DTO.
        /// </summary>
        /// <param name="userDto">The DTO containing the user data for creation.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        Task<IdentityResult> CreateUserAsync(UserCreateDto userDto);

        /// <summary>
        /// Updates an existing user based on the provided user update DTO.
        /// </summary>
        /// <param name="userId">The ID of the user to update.</param>
        /// <param name="userDto">The DTO containing the updated data for the user.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        Task<IdentityResult> UpdateUserAsync(int userId, UserUpdateDto userDto);

        /// <summary>
        /// Deletes a user based on their ID.
        /// </summary>
        /// <param name="userId">The ID of the user to delete.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        Task<IdentityResult> DeleteUserAsync(int userId);
    }
}

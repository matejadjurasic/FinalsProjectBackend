using FitnessPalAPI.Models.DataTransferModels.UserTransferModels;
using FitnessPalAPI.Services.UserServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FitnessPalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserReadDto>>> GetUsers()
        {
            var users = await _userService.GetAllUsersAsync();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserReadDto>> GetUser(int id)
        {
            var user = await _userService.GetUserByIdAsync(id);
            if (user == null)
                return NotFound();
            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> PostUser(UserCreateDto userDto)
        {
            await _userService.CreateUserAsync(userDto);
            return CreatedAtAction(nameof(GetUser), new { id = userDto.Username }, userDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(int id, UserUpdateDto userDto)
        {
            var updateResult = await _userService.UpdateUserAsync(id, userDto);
            // Check if the update was successful
            if (updateResult.Succeeded)
            {
                // Retrieve the updated user details to return
                var updatedUser = await _userService.GetUserByIdAsync(id);
                if (updatedUser != null)
                {
                    return Ok(updatedUser);
                }
                else
                {
                    return NotFound("The updated user could not be found.");
                }
            }

            // If the update wasn't successful, return an error response
            return BadRequest(updateResult.Errors.Select(e => e.Description));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            await _userService.DeleteUserAsync(id);
            return Ok("User deleted successfully");
        }
    }
}

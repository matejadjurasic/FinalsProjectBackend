using AutoMapper;
using FitnessPalAPI.Models.DatabaseModels;
using FitnessPalAPI.Models.DataTransferModels.UserTransferModels;
using Microsoft.AspNetCore.Identity;

namespace FitnessPalAPI.Services.UserServices
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<UserReadDto>> GetAllUsersAsync()
        {
            var users = await _userRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<UserReadDto>>(users);
        }

        public async Task<UserReadDto> GetUserByIdAsync(int userId)
        {
            var user = await _userRepository.GetByIdAsync(userId);
            return _mapper.Map<UserReadDto>(user);
        }

        public async Task<IdentityResult> CreateUserAsync(UserCreateDto userDto)
        {
            var user = _mapper.Map<User>(userDto);
            return await _userRepository.AddAsync(user, userDto.Password);
        }

        public async Task<IdentityResult> UpdateUserAsync(int userId, UserUpdateDto userDto)
        {
            var user = await _userRepository.GetByIdAsync(userId);
            if (user != null)
            {
                _mapper.Map(userDto, user);
                return await _userRepository.UpdateAsync(user);
            }
            return IdentityResult.Failed(new IdentityError { Description = "User not found." });
        }

        public async Task<IdentityResult> DeleteUserAsync(int userId)
        {
            return await _userRepository.DeleteAsync(userId);
        }
    }
}

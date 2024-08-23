using AutoMapper;
using FitnessPalAPI.Exceptions;
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
            var user = await _userRepository.GetByIdAsync(userId) ?? throw new NotFoundException("User not found");
            return _mapper.Map<UserReadDto>(user);
        }

        public async Task<UserReadDto> CreateUserAsync(UserCreateDto userDto)
        {
            var user = _mapper.Map<User>(userDto);
            var result = await _userRepository.AddAsync(user, userDto.Password);
            if (!result.Succeeded)
            {
                throw new InvalidOperationException("Failed to create user: " + string.Join(", ", result.Errors.Select(e => e.Description)));
            }
            return _mapper.Map<UserReadDto>(user);
        }

        public async Task<UserReadDto> UpdateUserAsync(int userId, UserUpdateDto userDto)
        {
            var user = await _userRepository.GetByIdAsync(userId) ?? throw new NotFoundException("User not found");
            _mapper.Map(userDto, user);
            var result = await _userRepository.UpdateAsync(user);
            if (!result.Succeeded)
            {
                throw new InvalidOperationException("Failed to update user: " + string.Join(", ", result.Errors.Select(e => e.Description)));
            }
            return _mapper.Map<UserReadDto>(user);
        }

        public async Task DeleteUserAsync(int userId)
        {
            var user = await _userRepository.GetByIdAsync(userId) ?? throw new NotFoundException("User not found");
            var result = await _userRepository.DeleteAsync(user);
            if (!result.Succeeded)
            {
                throw new InvalidOperationException("Failed to delete user: " + string.Join(", ", result.Errors.Select(e => e.Description)));
            }
        }
    }
}

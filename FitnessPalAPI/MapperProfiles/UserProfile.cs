using AutoMapper;
using FitnessPalAPI.Models.DatabaseModels;
using FitnessPalAPI.Models.DataTransferModels.UserTransferModels;

namespace FitnessPalAPI.MapperProfiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserReadDto>();
            CreateMap<UserCreateDto, User>();
            CreateMap<UserUpdateDto, User>();
        }
    }
}

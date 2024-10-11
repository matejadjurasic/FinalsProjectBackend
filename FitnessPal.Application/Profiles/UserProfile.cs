using AutoMapper;
using FitnessPal.Domain.Models;
using FitnessPal.Application.DTOs.UserDTOs;

namespace FitnessPal.Application.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserReadDto>().ReverseMap();
            CreateMap<User, UserCreateDto>().ReverseMap();
            CreateMap<User, UserUpdateDto>().ReverseMap();
        }
    }
}

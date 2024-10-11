using AutoMapper;
using FitnessPal.Domain.Models;
using FitnessPal.Application.DTOs.GoalDTOs;

namespace FitnessPal.Application.Profiles
{
    public class GoalProfile : Profile
    {
        public GoalProfile() 
        {
            CreateMap<Goal, GoalReadDto>().ReverseMap();
            CreateMap<Goal, GoalCreateDto>().ReverseMap();
            CreateMap<Goal, GoalUpdateDto>().ReverseMap();
        }
    }
}

using AutoMapper;
using FitnessPal.Domain.Models;
using FitnessPal.Application.DTOs.MealDTOs;

namespace FitnessPal.Application.Profiles
{
    public class MealProfile : Profile
    {
        public MealProfile() 
        {
            CreateMap<Meal, MealReadDto>().ReverseMap();
            CreateMap<Meal, MealCreateDto>().ReverseMap();
            CreateMap<Meal, MealUpdateDto>().ReverseMap();
        }
    }
}

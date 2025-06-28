using AutoMapper;
using FitnessPal.Domain.Models;
using FitnessPal.Application.DTOs.MealItemDTOs;

namespace FitnessPal.Application.Profiles
{
    public class MealItemProfile : Profile
    {
        public MealItemProfile() 
        {
            CreateMap<MealItem, MealItemReadDto>().ReverseMap();
            CreateMap<MealItem, MealItemCreateDto>().ReverseMap()
                .ForMember(dest => dest.Meal, opt => opt.Ignore())
                .ForMember(dest => dest.Ingredient, opt => opt.Ignore());
            CreateMap<MealItem, MealItemUpdateDto>().ReverseMap();
        }
    }
}

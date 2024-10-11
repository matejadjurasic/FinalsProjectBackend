using AutoMapper;
using FitnessPal.Application.DTOs.IngredientDTOs;
using FitnessPal.Domain.Models;

namespace FitnessPal.Application.Profiles
{
    public class IngredientProfile : Profile
    {
        public IngredientProfile() 
        {
            CreateMap<Ingredient, IngredientReadDto>().ReverseMap();
            CreateMap<Ingredient, IngredientCreateDto>().ReverseMap();
            CreateMap<Ingredient, IngredientUpdateDto>().ReverseMap();
        }
    }
}

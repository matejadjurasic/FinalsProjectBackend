using AutoMapper;
using FitnessPalAPI.Models.DatabaseModels;
using FitnessPalAPI.Models.DataTransferModels.FoodTransferModels;

namespace FitnessPalAPI.MapperProfiles
{
    public class FoodProfile : Profile
    {
        public FoodProfile() 
        {
            CreateMap<Food, FoodReadDto>();
            CreateMap<FoodCreateDto, Food>();
            CreateMap<FoodUpdateDto, Food>();
        }
    }
}

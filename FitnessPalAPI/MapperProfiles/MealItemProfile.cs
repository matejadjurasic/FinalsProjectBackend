using AutoMapper;
using FitnessPalAPI.Models.DatabaseModels;
using FitnessPalAPI.Models.DataTransferModels.MealItemTransferModels;

namespace FitnessPalAPI.MapperProfiles
{
    public class MealItemProfile : Profile
    {
        public MealItemProfile() 
        {
            CreateMap<MealItem, MealItemReadDto>();
            CreateMap<MealItemCreateDto, MealItem>();
            CreateMap<MealItemUpdateDto, MealItem>()
                .ForPath(dest => dest.Amount, opt => opt.MapFrom(src => src.Amount));
        }
    }
}

using AutoMapper;
using FitnessPalAPI.Models.DatabaseModels;
using FitnessPalAPI.Models.DataTransferModels.DailyWeightTransferModels;
using FitnessPalAPI.Models.DataTransferModels.MealItemTransferModels;

namespace FitnessPalAPI.MapperProfiles
{
    public class DailyWeightProfile : Profile
    {
        public DailyWeightProfile() 
        {
            CreateMap<DailyWeight, DailyWeightReadDto>();
            CreateMap<DailyWeightCreateDto, DailyWeight>();
            CreateMap<DailyWeightUpdateDto, DailyWeight>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}

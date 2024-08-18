using AutoMapper;
using FitnessPalAPI.Models.DatabaseModels;
using FitnessPalAPI.Models.DataTransferModels.MealTransferModels;

namespace FitnessPalAPI.MapperProfiles
{
    public class MealProfile : Profile
    {
        public MealProfile() 
        {
            CreateMap<Meal, MealReadDto>();
            CreateMap<MealCreateDto, Meal>();
            CreateMap<MealUpdateDto, Meal>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}

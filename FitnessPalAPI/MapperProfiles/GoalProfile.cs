using AutoMapper;
using FitnessPalAPI.Models.DatabaseModels;
using FitnessPalAPI.Models.DataTransferModels.GoalTransferModels;

namespace FitnessPalAPI.MapperProfiles
{
    public class GoalProfile : Profile
    {
        public GoalProfile() 
        {
            CreateMap<Goal, GoalReadDto>();
            CreateMap<GoalCreateDto, Goal>();
            CreateMap<GoalUpdateDto, Goal>();
        }
    }
}

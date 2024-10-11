using AutoMapper;
using FitnessPal.Application.DTOs.DailyWeightDTOs;
using FitnessPal.Domain.Models;

namespace FitnessPal.Application.Profiles
{
    public class DailyWeightProfile : Profile
    {
        public DailyWeightProfile() 
        {
            CreateMap<DailyWeight, DailyWeightReadDto>().ReverseMap();
            CreateMap<DailyWeight, DailyWeightCreateDto>().ReverseMap();
            CreateMap<DailyWeight, DailyWeightUpdateDto>().ReverseMap();
        }
    }
}

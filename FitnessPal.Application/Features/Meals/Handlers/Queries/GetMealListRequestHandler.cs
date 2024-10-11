using AutoMapper;
using FitnessPal.Application.Contracts.Persistence;
using FitnessPal.Application.DTOs.MealDTOs;
using FitnessPal.Application.Features.Meals.Requests.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessPal.Application.Features.Meals.Handlers.Queries
{
    public class GetMealListRequestHandler : IRequestHandler<GetMealListRequest,List<MealReadDto>>
    {
        private readonly IMealRepository _mealRepository;
        private readonly IMapper _mapper;

        public GetMealListRequestHandler(IMealRepository mealRepository, IMapper mapper)
        {
            _mealRepository = mealRepository;
            _mapper = mapper;
        }

        public async Task<List<MealReadDto>> Handle(GetMealListRequest request, CancellationToken cancellationToken)
        {
            var meals = await _mealRepository.GetMealsByDate(request.Date, request.UserId);
            return _mapper.Map<List<MealReadDto>>(meals);
        }
    }
}

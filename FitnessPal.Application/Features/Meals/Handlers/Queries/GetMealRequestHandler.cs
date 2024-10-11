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
    public class GetMealRequestHandler : IRequestHandler<GetMealRequest, MealReadDto>
    {
        private readonly IMealRepository _mealRepository;
        private readonly IMapper _mapper;

        public GetMealRequestHandler(IMealRepository mealRepository, IMapper mapper)
        {
            _mealRepository = mealRepository;
            _mapper = mapper;
        }

        public async Task<MealReadDto> Handle(GetMealRequest request, CancellationToken cancellationToken)
        {
            var meal = await _mealRepository.GetAsync(request.Id);

            if (meal.UserId != request.UserId)
                throw new InvalidOperationException("Unauthorized access");

            return _mapper.Map<MealReadDto>(meal);
        }
    }
}

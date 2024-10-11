using AutoMapper;
using FitnessPal.Application.Contracts.Persistence;
using FitnessPal.Application.DTOs.MealItemDTOs;
using FitnessPal.Application.Features.MealItems.Requests.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessPal.Application.Features.MealItems.Handlers.Queries
{
    public class GetMealItemRequestHandler : IRequestHandler<GetMealItemRequest, MealItemReadDto>
    {
        private readonly IMealItemRepository _mealItemRepository;
        private readonly IMapper _mapper;

        public GetMealItemRequestHandler(IMealItemRepository mealItemRepository, IMapper mapper)
        {
            _mealItemRepository = mealItemRepository;
            _mapper = mapper;
        }

        public async Task<MealItemReadDto> Handle(GetMealItemRequest request, CancellationToken cancellationToken)
        {
            var mealItem = await _mealItemRepository.GetMealItem(request.MealId, request.IngredientId);
            return _mapper.Map<MealItemReadDto>(mealItem);
        }
    }
}

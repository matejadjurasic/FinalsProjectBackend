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
    public class GetMealItemListRequestHandler : IRequestHandler<GetMealItemListRequest,List<MealItemReadDto>>
    {
        private readonly IMealItemRepository _mealItemRepository;
        private readonly IMapper _mapper;

        public GetMealItemListRequestHandler(IMealItemRepository mealItemRepository, IMapper mapper)
        {
            _mealItemRepository = mealItemRepository;
            _mapper = mapper;
        }

        public async Task<List<MealItemReadDto>> Handle(GetMealItemListRequest request, CancellationToken cancellationToken)
        {
            var mealItems = await _mealItemRepository.GetMealItems(request.MealId);
            return _mapper.Map<List<MealItemReadDto>>(mealItems);
        }
    }
}

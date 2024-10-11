using AutoMapper;
using FitnessPal.Application.DTOs.IngredientDTOs;
using FitnessPal.Application.Features.Ingredients.Requests.Queries;
using FitnessPal.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessPal.Application.Features.Ingredients.Handlers.Queries
{
    public class GetIngredientListRequestHandler : IRequestHandler<GetIngredientListRequest, List<IngredientReadDto>>
    {
        private readonly IIngredientRepository _ingredientRepository;
        private readonly IMapper _mapper;

        public GetIngredientListRequestHandler(IIngredientRepository ingredientRepository, IMapper mapper)
        {
            _ingredientRepository = ingredientRepository;
            _mapper = mapper;
        }

        public async Task<List<IngredientReadDto>> Handle(GetIngredientListRequest request, CancellationToken cancellationToken)
        {
            var ingredients = await _ingredientRepository.GetAllAsync();
            return _mapper.Map<List<IngredientReadDto>>(ingredients);
        }
    }
}

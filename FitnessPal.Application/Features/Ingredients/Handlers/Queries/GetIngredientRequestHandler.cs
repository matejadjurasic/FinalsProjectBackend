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
using FitnessPal.Domain.Models;
using FitnessPal.Application.Exceptions;

namespace FitnessPal.Application.Features.Ingredients.Handlers.Queries
{
    public class GetIngredientRequestHandler : IRequestHandler<GetIngredientRequest, IngredientReadDto>
    {
        private readonly IIngredientRepository _ingredientRepository;
        private readonly IMapper _mapper;

        public GetIngredientRequestHandler(IIngredientRepository ingredientRepository, IMapper mapper)
        {
            _ingredientRepository = ingredientRepository;
            _mapper = mapper;
        }

        public async Task<IngredientReadDto> Handle(GetIngredientRequest request, CancellationToken cancellationToken)
        {
            var ingredient = await _ingredientRepository.GetAsync(request.Id);
            return _mapper.Map<IngredientReadDto>(ingredient);
        }
    }
}

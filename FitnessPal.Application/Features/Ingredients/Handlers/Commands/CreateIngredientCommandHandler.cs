using AutoMapper;
using FitnessPal.Application.Features.Ingredients.Requests.Commands;
using FitnessPal.Application.Contracts.Persistence;
using FitnessPal.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FitnessPal.Application.DTOs.IngredientDTOs.Validators;
using FitnessPal.Application.Exceptions;

namespace FitnessPal.Application.Features.Ingredients.Handlers.Commands
{
    public class CreateIngredientCommandHandler : IRequestHandler<CreateIngredientCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateIngredientCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreateIngredientCommand request, CancellationToken cancellationToken)
        {
            var ingredient = _mapper.Map<Ingredient>(request.IngredientCreateDto);
            ingredient = await _unitOfWork.IngredientRepository.AddAsync(ingredient);
            await _unitOfWork.Save();

            return ingredient.Id;
        }
    }
}

using AutoMapper;
using FitnessPal.Application.Features.Ingredients.Requests.Commands;
using FitnessPal.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FitnessPal.Application.DTOs.IngredientDTOs.Validators;
using FitnessPal.Application.Exceptions;
using FitnessPal.Domain.Models;

namespace FitnessPal.Application.Features.Ingredients.Handlers.Commands
{
    public class UpdateIngredientCommandHandler : IRequestHandler<UpdateIngredientCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateIngredientCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task Handle(UpdateIngredientCommand request, CancellationToken cancellationToken)
        {
            var ingredient = await _unitOfWork.IngredientRepository.GetAsync(request.Id);
            _mapper.Map(request.IngredientUpdateDto, ingredient);

            await _unitOfWork.IngredientRepository.UpdateAsync(ingredient);
            await _unitOfWork.Save();
        }
    }
}

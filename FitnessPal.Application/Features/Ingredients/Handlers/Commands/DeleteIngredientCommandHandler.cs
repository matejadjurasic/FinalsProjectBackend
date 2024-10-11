using AutoMapper;
using FitnessPal.Application.Features.Ingredients.Requests.Commands;
using FitnessPal.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FitnessPal.Domain.Models;
using FitnessPal.Application.Exceptions;

namespace FitnessPal.Application.Features.Ingredients.Handlers.Commands
{
    public class DeleteIngredientCommandHandler : IRequestHandler<DeleteIngredientCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteIngredientCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task Handle(DeleteIngredientCommand request, CancellationToken cancellationToken)
        {
            var ingredient = await _unitOfWork.IngredientRepository.GetAsync(request.Id);
            await _unitOfWork.IngredientRepository.DeleteAsync(ingredient);
            await _unitOfWork.Save();
        }
    }
}

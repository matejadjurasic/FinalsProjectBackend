using AutoMapper;
using FitnessPal.Application.Contracts.Persistence;
using FitnessPal.Application.Features.Meals.Requests.Commands;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessPal.Application.Features.Meals.Handlers.Commands
{
    public class DeleteMealCommandHandler : IRequestHandler<DeleteMealCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteMealCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task Handle(DeleteMealCommand request, CancellationToken cancellationToken)
        {
            var meal = await _unitOfWork.MealRepository.GetAsync(request.Id);

            if (meal.UserId != request.UserId)
                throw new InvalidOperationException("Unauthorized access");

            await _unitOfWork.MealRepository.DeleteAsync(meal);
            await _unitOfWork.Save();
        }
    }
}

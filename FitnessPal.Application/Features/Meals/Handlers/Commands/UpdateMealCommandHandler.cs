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
    public class UpdateMealCommandHandler : IRequestHandler<UpdateMealCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateMealCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task Handle(UpdateMealCommand request, CancellationToken cancellationToken)
        {
            var meal = await _unitOfWork.MealRepository.GetAsync(request.Id);

            if(meal.UserId != request.UserId)
                throw new InvalidOperationException("Unauthorized access");

            _mapper.Map(request.MealUpdateDto, meal);

            await _unitOfWork.MealRepository.UpdateAsync(meal);
            await _unitOfWork.Save();
        }
    }
}

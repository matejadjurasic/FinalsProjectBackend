using AutoMapper;
using FitnessPal.Application.Contracts.Persistence;
using FitnessPal.Application.Features.Meals.Requests.Commands;
using FitnessPal.Application.Features.Meals.Requests.Queries;
using FitnessPal.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessPal.Application.Features.Meals.Handlers.Commands
{
    public class CreateMealCommandHandler : IRequestHandler<CreateMealCommand,int>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateMealCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreateMealCommand request, CancellationToken cancellationToken)
        {
            if (request.MealCreateDto != null)
                request.MealCreateDto.UserId = request.UserId;

            var meal = _mapper.Map<Meal>(request.MealCreateDto);
            meal = await _unitOfWork.MealRepository.AddAsync(meal);
            await _unitOfWork.Save();

            return meal.Id;
        }
    }
}

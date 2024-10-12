using AutoMapper;
using FitnessPal.Application.Contracts.Infrastructure;
using FitnessPal.Application.Contracts.Persistence;
using FitnessPal.Application.Features.Goals.Requests.Commands;
using FitnessPal.Application.Models.Nutrition;
using FitnessPal.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessPal.Application.Features.Goals.Handlers.Commands
{
    public class CreateInitialGoalCommandHandler : IRequestHandler<CreateInitialGoalCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly INutritionCalculatorService _nutritionCalculator;

        public CreateInitialGoalCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, INutritionCalculatorService nutritionCalculator)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _nutritionCalculator = nutritionCalculator;
        }

        public async Task<int> Handle(CreateInitialGoalCommand request, CancellationToken cancellationToken)
        {
            var goalDto = request.InitialGoalCreateDto;

            var userInfo = new UserInfo
            {
                Weight = goalDto!.Weight,
                Height = goalDto.Height,
                Age = goalDto.Age,
                Gender = goalDto.Gender,
                ActivityLevel = goalDto.ActivityLevel,
                GoalType = goalDto.Type
            };

            var nutritionGoals = _nutritionCalculator.CalculateGoals(userInfo);

            var goal = new Goal
            {
                UserId = request.UserId,
                TargetCalories = nutritionGoals.TargetCalories,
                TargetProtein = nutritionGoals.TargetProtein,
                TargetCarbs = nutritionGoals.TargetCarbs,
                ActivityLevel = goalDto.ActivityLevel,
                TargetFats = nutritionGoals.TargetFats,
                TargetWeight = goalDto.TargetWeight ?? userInfo.Weight,
                Type = goalDto.Type
            };

            await _unitOfWork.GoalRepository.AddAsync(goal);
            await _unitOfWork.Save();

            return goal.Id;
        }
    }
}

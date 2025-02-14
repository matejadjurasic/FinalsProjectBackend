using AutoMapper;
using FitnessPal.Application.Contracts.Persistence;
using FitnessPal.Application.Exceptions;
using FitnessPal.Application.Features.MealItems.Requests.Commands;
using FitnessPal.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessPal.Application.Features.MealItems.Handlers.Commands
{
    public class CreateMealItemCommandHandler : IRequestHandler<CreateMealItemCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateMealItemCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<int> Handle(CreateMealItemCommand request, CancellationToken cancellationToken)
        {
            var mealItem = _mapper.Map<MealItem>(request.MealItemCreateDto);
            var exists = await _unitOfWork.MealItemRepository.MealItemExists(mealItem.MealId, mealItem.IngredientId);
            if(exists) throw new ItemAlreadyExistsException("MealItem already exists");

            var ingredient = await _unitOfWork.IngredientRepository.GetAsync(mealItem.IngredientId);
            var meal = await _unitOfWork.MealRepository.GetAsync(mealItem.MealId);

            double amountFactor = mealItem.Amount / 100.0;

            int caloriesContribution = (int)(ingredient.Calories * amountFactor);
            double proteinContribution = ingredient.Protein * amountFactor;
            double carbsContribution = ingredient.Carbs * amountFactor;
            double fatContribution = ingredient.Fat * amountFactor;

            meal.Calories += caloriesContribution;
            meal.Protein += proteinContribution;
            meal.Carbs += carbsContribution;
            meal.Fat += fatContribution;

            await _unitOfWork.MealItemRepository.AddAsync(mealItem);
            await _unitOfWork.MealRepository.UpdateAsync(meal);

            await _unitOfWork.Save();

            return mealItem.IngredientId;
        }
    }
}

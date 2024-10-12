using AutoMapper;
using FitnessPal.Application.Contracts.Persistence;
using FitnessPal.Application.Features.MealItems.Requests.Commands;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessPal.Application.Features.MealItems.Handlers.Commands
{
    public class DeleteMealItemCommandHandler : IRequestHandler<DeleteMealItemCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteMealItemCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(DeleteMealItemCommand request, CancellationToken cancellationToken)
        {
            var mealItem = await _unitOfWork.MealItemRepository.GetMealItem(request.MealId, request.IngredientId);
            var ingredient = await _unitOfWork.IngredientRepository.GetAsync(request.IngredientId);
            var meal = await _unitOfWork.MealRepository.GetAsync(request.MealId);

            var amountFactor = mealItem.Amount / 100.0;

            var caloriesContribution = (int)(ingredient.Calories * amountFactor);
            var proteinContribution = ingredient.Protein * amountFactor;
            var carbsContribution = ingredient.Carbs * amountFactor;
            var fatContribution = ingredient.Fat * amountFactor;

            meal.Calories -= caloriesContribution;
            meal.Protein -= proteinContribution;
            meal.Carbs -= carbsContribution;
            meal.Fat -= fatContribution;

            await _unitOfWork.MealItemRepository.DeleteAsync(mealItem);
            await _unitOfWork.MealRepository.UpdateAsync(meal);

            await _unitOfWork.Save();
        }
    }
}

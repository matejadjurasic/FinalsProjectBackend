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
    public class UpdateMealItemCommandHandler : IRequestHandler<UpdateMealItemCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateMealItemCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(UpdateMealItemCommand request, CancellationToken cancellationToken)
        {
            var mealItem = await _unitOfWork.MealItemRepository.GetMealItem(request.MealId, request.IngredientId);
            _mapper.Map(request.MealItemUpdateDto, mealItem);

            await _unitOfWork.MealItemRepository.UpdateAsync(mealItem);
            await _unitOfWork.Save();
        }
    }
}

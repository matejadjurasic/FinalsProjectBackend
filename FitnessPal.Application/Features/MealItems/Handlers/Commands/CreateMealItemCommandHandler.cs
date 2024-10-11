using AutoMapper;
using FitnessPal.Application.Contracts.Persistence;
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
            mealItem = await _unitOfWork.MealItemRepository.AddAsync(mealItem);
            await _unitOfWork.Save();

            return mealItem.IngredientId;
        }
    }
}

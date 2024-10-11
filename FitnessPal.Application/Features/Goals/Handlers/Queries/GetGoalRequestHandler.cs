using AutoMapper;
using FitnessPal.Application.Contracts.Persistence;
using FitnessPal.Application.DTOs.GoalDTOs;
using FitnessPal.Application.DTOs.IngredientDTOs;
using FitnessPal.Application.Features.Goals.Requests.Queries;
using FitnessPal.Application.Features.Ingredients.Requests.Queries;
using FitnessPal.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessPal.Application.Features.Goals.Handlers.Queries
{
    public class GetGoalRequestHandler : IRequestHandler<GetGoalRequest,GoalReadDto>
    {
        private readonly IGoalRepository _goalRepository;
        private readonly IMapper _mapper;

        public GetGoalRequestHandler(IGoalRepository goalRepository, IMapper mapper)
        {
            _goalRepository = goalRepository;
            _mapper = mapper;
        }

        public async Task<GoalReadDto> Handle(GetGoalRequest request, CancellationToken cancellationToken)
        {
            var goal = await _goalRepository.GetAsync(request.Id);

            if (goal.UserId != request.UserId)
                throw new InvalidOperationException("Unathorized access");

            return _mapper.Map<GoalReadDto>(goal);
        }
    }
}

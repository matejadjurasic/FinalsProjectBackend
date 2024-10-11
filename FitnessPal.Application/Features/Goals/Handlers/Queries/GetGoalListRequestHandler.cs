using AutoMapper;
using FitnessPal.Application.Contracts.Persistence;
using FitnessPal.Application.DTOs.GoalDTOs;
using FitnessPal.Application.Features.Goals.Requests.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessPal.Application.Features.Goals.Handlers.Queries
{
    public class GetGoalListRequestHandler : IRequestHandler<GetGoalListRequest, List<GoalReadDto>>
    {
        private readonly IGoalRepository _goalRepository;
        private readonly IMapper _mapper;

        public GetGoalListRequestHandler(IGoalRepository goalRepository, IMapper mapper)
        {
            _goalRepository = goalRepository;
            _mapper = mapper;
        }

        public async Task<List<GoalReadDto>> Handle(GetGoalListRequest request, CancellationToken cancellationToken)
        {
            var goals = await _goalRepository.GetGoalsByUserIdAsync(request.UserId);
            return _mapper.Map<List<GoalReadDto>>(goals);
        }
    }
}

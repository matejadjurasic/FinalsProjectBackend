using AutoMapper;
using FitnessPal.Application.Contracts.Persistence;
using FitnessPal.Application.Features.Goals.Requests.Commands;
using FitnessPal.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessPal.Application.Features.Goals.Handlers.Commands
{
    public class CreateGoalCommandHandler : IRequestHandler<CreateGoalCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateGoalCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreateGoalCommand request, CancellationToken cancellationToken)
        {
            if (request.GoalCreateDto != null)
                request.GoalCreateDto.UserId = request.UserId;

            var goal = _mapper.Map<Goal>(request.GoalCreateDto);
            goal = await _unitOfWork.GoalRepository.AddAsync(goal);
            await _unitOfWork.Save();

            return goal.Id;
        }
    }
}

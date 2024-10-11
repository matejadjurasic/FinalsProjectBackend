using AutoMapper;
using FitnessPal.Application.Contracts.Persistence;
using FitnessPal.Application.Features.Goals.Requests.Commands;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessPal.Application.Features.Goals.Handlers.Commands
{
    public class UpdateGoalCommandHandler : IRequestHandler<UpdateGoalCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateGoalCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task Handle(UpdateGoalCommand request, CancellationToken cancellationToken)
        {
            var goal = await _unitOfWork.GoalRepository.GetAsync(request.Id);

            if (goal.UserId != request.UserId)
                throw new InvalidOperationException("Unathorized access");

            _mapper.Map(request.GoalUpdateDto, goal);

            await _unitOfWork.GoalRepository.UpdateAsync(goal);
            await _unitOfWork.Save();
        }
    }
}

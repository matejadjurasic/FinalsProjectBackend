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
    public class DeleteGoalCommandHandler : IRequestHandler<DeleteGoalCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteGoalCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task Handle(DeleteGoalCommand request, CancellationToken cancellationToken)
        {
            var goal = await _unitOfWork.GoalRepository.GetAsync(request.Id);

            if (goal.UserId != request.UserId)
                throw new InvalidOperationException("Unathorized access");

            await _unitOfWork.GoalRepository.DeleteAsync(goal);
            await _unitOfWork.Save();
        }
    }
}

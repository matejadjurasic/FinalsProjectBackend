using AutoMapper;
using FitnessPal.Application.Contracts.Persistence;
using FitnessPal.Application.Features.DailyWeights.Requests.Commands;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessPal.Application.Features.DailyWeights.Handlers.Commands
{
    public class DeleteDailyWeightCommandHandler : IRequestHandler<DeleteDailyWeightCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteDailyWeightCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(DeleteDailyWeightCommand request, CancellationToken cancellationToken)
        {
            var dailyWeight = await _unitOfWork.DailyWeightRepository.GetAsync(request.Id);

            if (dailyWeight.UserId != request.UserId)
                throw new InvalidOperationException("Unathorized access");

            await _unitOfWork.DailyWeightRepository.DeleteAsync(dailyWeight);
            await _unitOfWork.Save();
        }
    }
}

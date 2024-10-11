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
    public class UpdateDailyWeightCommandHandler : IRequestHandler<UpdateDailyWeightCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateDailyWeightCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(UpdateDailyWeightCommand request, CancellationToken cancellationToken)
        {
            var dailyWeight = await _unitOfWork.DailyWeightRepository.GetAsync(request.Id);

            if (dailyWeight.UserId != request.UserId)
                throw new InvalidOperationException("Unathorized access");

            _mapper.Map(request.DailyWeightUpdateDto, dailyWeight);

            await _unitOfWork.DailyWeightRepository.UpdateAsync(dailyWeight);
            await _unitOfWork.Save();
        }
    }
}

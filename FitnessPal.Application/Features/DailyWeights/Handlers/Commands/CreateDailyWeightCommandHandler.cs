using AutoMapper;
using FitnessPal.Application.Contracts.Persistence;
using FitnessPal.Application.Features.DailyWeights.Requests.Commands;
using FitnessPal.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessPal.Application.Features.DailyWeights.Handlers.Commands
{
    public class CreateDailyWeightCommandHandler : IRequestHandler<CreateDailyWeightCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateDailyWeightCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<int> Handle(CreateDailyWeightCommand request, CancellationToken cancellationToken)
        {
            if(request.DailyWeightCreateDto != null)
                request.DailyWeightCreateDto.UserId = request.UserId;

            var dailyWeight = _mapper.Map<DailyWeight>(request.DailyWeightCreateDto);
            dailyWeight = await _unitOfWork.DailyWeightRepository.AddAsync(dailyWeight);
            await _unitOfWork.Save();

            return dailyWeight.Id;
        }
    }
}

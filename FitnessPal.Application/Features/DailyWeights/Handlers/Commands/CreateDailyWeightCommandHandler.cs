using AutoMapper;
using FitnessPal.Application.Contracts.Persistence;
using FitnessPal.Application.Exceptions;
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
            var dw = await _unitOfWork.DailyWeightRepository.GetDailyWeightByDateAsync(request.DailyWeightCreateDto!.DateTime, request.UserId);
            if (dw != null)
                throw new InvalidOperationException("You have already entered your weight for the day");

            request.DailyWeightCreateDto!.UserId = request.UserId;

            var dailyWeight = _mapper.Map<DailyWeight>(request.DailyWeightCreateDto);
            dailyWeight = await _unitOfWork.DailyWeightRepository.AddAsync(dailyWeight);

            var user = await _unitOfWork.UserRepository.GetAsync(request.UserId);
            user.Weight = dailyWeight.Weight;

            await _unitOfWork.UserRepository.UpdateAsync(user);

            await _unitOfWork.Save();

            return dailyWeight.Id;
        }
    }
}

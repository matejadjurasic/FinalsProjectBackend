using AutoMapper;
using FitnessPal.Application.Contracts.Persistence;
using FitnessPal.Application.DTOs.DailyWeightDTOs;
using FitnessPal.Application.Features.DailyWeights.Requests.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessPal.Application.Features.DailyWeights.Handlers.Queries
{
    public class GetDailyWeightRequestHandler : IRequestHandler<GetDailyWeightRequest,DailyWeightReadDto>
    {
        private readonly IDailyWeightRepository _dailyWeightRepository;
        private readonly IMapper _mapper;

        public GetDailyWeightRequestHandler(IDailyWeightRepository dailyWeightRepository, IMapper mapper)
        {
            _dailyWeightRepository = dailyWeightRepository;
            _mapper = mapper;
        }

        public async Task<DailyWeightReadDto> Handle(GetDailyWeightRequest request, CancellationToken cancellationToken)
        {
            var dailyWeight = await _dailyWeightRepository.GetAsync(request.Id);

            if (dailyWeight.UserId != request.UserId)
                throw new InvalidOperationException("Unathorized access");

            return _mapper.Map<DailyWeightReadDto>(dailyWeight);
        }
    }
}

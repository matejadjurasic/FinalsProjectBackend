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
    public class GetDailyWeightListRequestHandler : IRequestHandler<GetDailyWeightListRequest, List<DailyWeightReadDto>>
    {
        private readonly IDailyWeightRepository _dailyWeightRepository;
        private readonly IMapper _mapper;

        public GetDailyWeightListRequestHandler(IDailyWeightRepository dailyWeightRepository, IMapper mapper)
        {
            _dailyWeightRepository = dailyWeightRepository;
            _mapper = mapper;
        }

        public async Task<List<DailyWeightReadDto>> Handle(GetDailyWeightListRequest request, CancellationToken cancellationToken)
        {
            var dailyWeights = await _dailyWeightRepository.GetDailyWeightsByUserIdAsync(request.UserId);
            return _mapper.Map<List<DailyWeightReadDto>>(dailyWeights);
        }
    }
}

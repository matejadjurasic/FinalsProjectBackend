using AutoMapper;
using FitnessPal.Application.Contracts.Persistence;
using FitnessPal.Application.DTOs.DailyWeightDTOs;
using FitnessPal.Application.Exceptions;
using FitnessPal.Application.Features.DailyWeights.Requests.Queries;
using FitnessPal.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace FitnessPal.Application.Features.DailyWeights.Handlers.Queries
{
    public class GetDailyWeightByDateRequestHandler : IRequestHandler<GetDailyWeightByDateRequest, DailyWeightReadDto>
    {
        private readonly IDailyWeightRepository _dailyWeightRepository;
        private readonly IMapper _mapper;

        public GetDailyWeightByDateRequestHandler(IDailyWeightRepository dailyWeightRepository, IMapper mapper)
        {
            _dailyWeightRepository = dailyWeightRepository;
            _mapper = mapper;
        }

        public async Task<DailyWeightReadDto> Handle(GetDailyWeightByDateRequest request, CancellationToken cancellationToken)
        {
            var dailyWeight = await _dailyWeightRepository.GetDailyWeightByDateAsync(request.Date, request.UserId);

            if (dailyWeight == null)
                throw new NotFoundException(nameof(DailyWeight), request.Date);

            return _mapper.Map<DailyWeightReadDto>(dailyWeight);
        }
    }
}

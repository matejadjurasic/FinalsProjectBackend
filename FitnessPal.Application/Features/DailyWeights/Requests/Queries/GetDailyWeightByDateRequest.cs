using FitnessPal.Application.DTOs.DailyWeightDTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessPal.Application.Features.DailyWeights.Requests.Queries
{
    public class GetDailyWeightByDateRequest : IRequest<DailyWeightReadDto>
    {
        public int UserId { get; set; }
        public DateTime Date { get; set; }
    }
}

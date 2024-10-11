using FitnessPal.Application.DTOs.DailyWeightDTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessPal.Application.Features.DailyWeights.Requests.Commands
{
    public class UpdateDailyWeightCommand : IRequest
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public DailyWeightUpdateDto? DailyWeightUpdateDto { get; set; }
    }
}

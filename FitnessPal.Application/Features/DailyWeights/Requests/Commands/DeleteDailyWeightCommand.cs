using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessPal.Application.Features.DailyWeights.Requests.Commands
{
    public class DeleteDailyWeightCommand : IRequest
    {
        public int Id { get; set; }
        public int UserId { get; set; }
    }
}

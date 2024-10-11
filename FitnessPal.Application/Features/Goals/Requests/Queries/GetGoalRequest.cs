using FitnessPal.Application.DTOs.GoalDTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessPal.Application.Features.Goals.Requests.Queries
{
    public class GetGoalRequest : IRequest<GoalReadDto>
    {
        public int Id { get; set; }
        public int UserId { get; set; }
    }
}

using FitnessPal.Application.DTOs.GoalDTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessPal.Application.Features.Goals.Requests.Queries
{
    public class GetGoalListRequest : IRequest<List<GoalReadDto>>
    {
        public int UserId { get; set; }
    }
}

using FitnessPal.Application.DTOs.GoalDTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessPal.Application.Features.Goals.Requests.Commands
{
    public class CreateGoalCommand : IRequest<int>
    {
        public int UserId { get; set; }
        public GoalCreateDto? GoalCreateDto { get; set; }
    }
}

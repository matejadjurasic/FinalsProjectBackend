using FitnessPal.Application.DTOs.GoalDTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessPal.Application.Features.Goals.Requests.Commands
{
    public class UpdateGoalCommand : IRequest
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public GoalUpdateDto? GoalUpdateDto { get; set; }
    }
}

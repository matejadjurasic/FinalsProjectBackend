using FitnessPal.Application.DTOs.MealDTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessPal.Application.Features.Meals.Requests.Commands
{
    public class CreateMealCommand : IRequest<int>
    {
        public MealCreateDto? MealCreateDto { get; set; }
        public int UserId { get; set; }
    }
}

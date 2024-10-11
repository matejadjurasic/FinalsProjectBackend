using FitnessPal.Application.DTOs.MealDTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessPal.Application.Features.Meals.Requests.Commands
{
    public class UpdateMealCommand : IRequest
    {
        public int Id { get; set; } 
        public int UserId { get; set; }
        public MealUpdateDto? MealUpdateDto { get; set; }
    }
}

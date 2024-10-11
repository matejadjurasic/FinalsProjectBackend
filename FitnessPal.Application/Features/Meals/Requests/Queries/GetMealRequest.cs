using FitnessPal.Application.DTOs.MealDTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessPal.Application.Features.Meals.Requests.Queries
{
    public class GetMealRequest : IRequest<MealReadDto>
    {
        public int Id { get; set; } 
        public int UserId { get; set; }
    }
}

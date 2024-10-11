using FitnessPal.Application.DTOs.MealDTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessPal.Application.Features.Meals.Requests.Queries
{
    public class GetMealListRequest : IRequest<List<MealReadDto>>
    {
        public DateTime Date { get; set; }
        public int UserId { get; set; }
    }
}

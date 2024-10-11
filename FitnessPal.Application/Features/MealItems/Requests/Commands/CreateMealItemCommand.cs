using FitnessPal.Application.DTOs.MealItemDTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessPal.Application.Features.MealItems.Requests.Commands
{
    public class CreateMealItemCommand : IRequest<int>
    {
        public MealItemCreateDto? MealItemCreateDto { get; set; }
    }
}

using FitnessPal.Application.DTOs.MealItemDTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessPal.Application.Features.MealItems.Requests.Commands
{
    public class UpdateMealItemCommand : IRequest
    {
        public int MealId { get; set; }
        public int IngredientId { get; set; }
        public MealItemUpdateDto? MealItemUpdateDto { get; set; }
    }
}

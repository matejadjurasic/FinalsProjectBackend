using FitnessPal.Application.DTOs.MealItemDTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessPal.Application.Features.MealItems.Requests.Queries
{
    public class GetMealItemRequest : IRequest<MealItemReadDto>
    {
        public int MealId { get; set; }
        public int IngredientId { get; set; }
    }
}

using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessPal.Application.Features.MealItems.Requests.Commands
{
    public class DeleteMealItemCommand : IRequest
    {
        public int MealId { get; set; }
        public int IngredientId { get; set; }
    }
}

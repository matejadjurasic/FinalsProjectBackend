using FitnessPal.Application.DTOs.IngredientDTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessPal.Application.Features.Ingredients.Requests.Commands
{
    public class CreateIngredientCommand : IRequest<int>
    {
        public IngredientCreateDto? IngredientCreateDto { get; set; }
    }
}

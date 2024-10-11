using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessPal.Application.DTOs.IngredientDTOs.Validators
{
    public class IngredientUpdateDtoValidator : AbstractValidator<IngredientUpdateDto>
    {
        public IngredientUpdateDtoValidator()
        {
            Include(new IngredientBaseDtoValidator());
        }
    }
}

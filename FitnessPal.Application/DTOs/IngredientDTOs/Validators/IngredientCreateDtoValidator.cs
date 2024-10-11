using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessPal.Application.DTOs.IngredientDTOs.Validators
{
    public class IngredientCreateDtoValidator : AbstractValidator<IngredientCreateDto>
    {
        public IngredientCreateDtoValidator()
        {
            Include(new IngredientBaseDtoValidator());
        }
    }
}

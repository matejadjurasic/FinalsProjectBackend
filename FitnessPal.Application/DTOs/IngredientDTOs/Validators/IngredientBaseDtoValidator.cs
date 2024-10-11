using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessPal.Application.DTOs.IngredientDTOs.Validators
{
    public class IngredientBaseDtoValidator : AbstractValidator<IngredientBaseDto>
    {
        public IngredientBaseDtoValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name is required.")
                .Length(1, 100).WithMessage("Name must be between 1 and 100 characters long.");

            RuleFor(x => x.Description)
                .MaximumLength(500).WithMessage("Description cannot exceed 500 characters.");

            RuleFor(x => x.Calories)
                .InclusiveBetween(0, int.MaxValue).WithMessage("Calories must be a non-negative number.");

            RuleFor(x => x.Protein)
                .GreaterThanOrEqualTo(0).WithMessage("Protein must be non-negative.");

            RuleFor(x => x.Carbs)
                .GreaterThanOrEqualTo(0).WithMessage("Carbs must be non-negative.");

            RuleFor(x => x.Fat)
                .GreaterThanOrEqualTo(0).WithMessage("Fat must be non-negative.");
        }
    }
}

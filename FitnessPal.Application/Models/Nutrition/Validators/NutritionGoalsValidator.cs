using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessPal.Application.Models.Nutrition.Validators
{
    public class NutritionGoalsValidator : AbstractValidator<NutritionGoals>
    {
        public NutritionGoalsValidator()
        {
            RuleFor(x => x.TargetCalories)
                .GreaterThanOrEqualTo(0)
                .WithMessage("Target Calories must be a non-negative number.");

            RuleFor(x => x.TargetProtein)
                .GreaterThanOrEqualTo(0)
                .WithMessage("Target Protein must be a non-negative number.");

            RuleFor(x => x.TargetCarbs)
                .GreaterThanOrEqualTo(0)
                .WithMessage("Target Carbs must be a non-negative number.");

            RuleFor(x => x.TargetFats)
                .GreaterThanOrEqualTo(0)
                .WithMessage("Target Fats must be a non-negative number.");
        }
    }
}

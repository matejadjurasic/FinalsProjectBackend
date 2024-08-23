using FitnessPalAPI.Models.DataTransferModels.GoalTransferModels;
using FluentValidation;

namespace FitnessPalAPI.Validators.GoalValidators
{
    public class GoalBaseDtoValidator : AbstractValidator<GoalBaseDto>
    {
        public GoalBaseDtoValidator()
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

            RuleFor(x => x.TargetWeight)
                .GreaterThanOrEqualTo(0)
                .WithMessage("Target Weight must be a non-negative number.");

            RuleFor(x => x.Type)
                .IsInEnum()
                .WithMessage("Type must be a valid enum value.");
        }
    }
}

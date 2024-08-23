using FitnessPalAPI.Models.DataTransferModels.MealTransferModels;
using FluentValidation;

namespace FitnessPalAPI.Validators.MealValidators
{
    public class MealBaseDtoValidator : AbstractValidator<MealBaseDto>
    {
        public MealBaseDtoValidator()
        {
            RuleFor(x => x.Calories)
                .InclusiveBetween(0, int.MaxValue)
                .WithMessage("Calories must be a non-negative number.");

            RuleFor(x => x.Protein)
                .GreaterThanOrEqualTo(0)
                .WithMessage("Protein must be a non-negative number.");

            RuleFor(x => x.Carbs)
                .GreaterThanOrEqualTo(0)
                .WithMessage("Carbs must be a non-negative number.");

            RuleFor(x => x.Fat)
                .GreaterThanOrEqualTo(0)
                .WithMessage("Fat must be a non-negative number.");

            RuleFor(x => x.DateTime)
                .NotEmpty()
                .WithMessage("DateTime must not be empty.");

            RuleFor(x => x.MealType)
                .IsInEnum()
                .WithMessage("Meal Type must be a valid enum value.");
        }
    }
}

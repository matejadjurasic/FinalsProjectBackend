using FitnessPalAPI.Models.DataTransferModels.MealItemTransferModels;
using FluentValidation;

namespace FitnessPalAPI.Validators.MealItemValidators
{
    public class MealItemBaseDtoValidator : AbstractValidator<MealItemBaseDto>
    {
        public MealItemBaseDtoValidator()
        {
            RuleFor(x => x.Amount)
                .GreaterThanOrEqualTo(0)
                .WithMessage("Amount must be a non-negative number.");
        }
    }
}

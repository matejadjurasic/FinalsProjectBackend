using FluentValidation;

namespace FitnessPal.Application.DTOs.MealItemDTOs.Validators
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

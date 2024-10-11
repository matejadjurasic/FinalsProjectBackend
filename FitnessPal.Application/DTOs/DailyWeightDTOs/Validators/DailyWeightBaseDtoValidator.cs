using FluentValidation;

namespace FitnessPal.Application.DTOs.DailyWeightDTOs.Validators
{
    public class DailyWeightBaseDtoValidator : AbstractValidator<DailyWeightBaseDto>
    {
        public DailyWeightBaseDtoValidator()
        {
            RuleFor(x => x.DateTime)
                .NotEmpty().WithMessage("Date and time are required.");

            RuleFor(x => x.Weight)
                .GreaterThan(0).WithMessage("Weight must be greater than zero.");
        }
    }
}

using FluentValidation;

namespace FitnessPal.Application.DTOs.DailyWeightDTOs.Validators
{
    public class DailyWeightBaseDtoValidator : AbstractValidator<DailyWeightBaseDto>
    {
        public DailyWeightBaseDtoValidator()
        {
            RuleFor(x => x.DateTime)
                .NotEmpty().WithMessage("Date and time are required.");
                
            RuleFor(x => x.DateTime.Date)
                .Must(date => date == DateTime.UtcNow.Date)
                .WithMessage("Daily weight entries can only be made for today.");

            RuleFor(x => x.Weight)
                .InclusiveBetween(1, 250).WithMessage("Weight must be between 1 and 250 kg");
        }
    }
}

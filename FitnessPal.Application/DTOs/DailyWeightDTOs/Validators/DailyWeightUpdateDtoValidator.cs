using FluentValidation;

namespace FitnessPal.Application.DTOs.DailyWeightDTOs.Validators
{
    public class DailyWeightUpdateDtoValidator : AbstractValidator<DailyWeightUpdateDto>
    {
        public DailyWeightUpdateDtoValidator()
        {
            Include(new DailyWeightBaseDtoValidator());
        }
    }
}

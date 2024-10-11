using FluentValidation;

namespace FitnessPal.Application.DTOs.DailyWeightDTOs.Validators
{
    public class DailyWeightCreateDtoValidator : AbstractValidator<DailyWeightCreateDto>
    {
        public DailyWeightCreateDtoValidator()
        {
            Include(new DailyWeightBaseDtoValidator());
        }
    }
}

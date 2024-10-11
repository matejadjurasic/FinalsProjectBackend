using FluentValidation;

namespace FitnessPal.Application.DTOs.MealDTOs.Validators
{
    public class MealCreateDtoValidator : AbstractValidator<MealCreateDto>
    {
        public MealCreateDtoValidator()
        {
            Include(new MealBaseDtoValidator());
        }
    }
}

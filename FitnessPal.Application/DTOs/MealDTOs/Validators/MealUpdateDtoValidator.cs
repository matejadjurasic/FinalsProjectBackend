using FluentValidation;

namespace FitnessPal.Application.DTOs.MealDTOs.Validators
{
    public class MealUpdateDtoValidator : AbstractValidator<MealUpdateDto>
    {
        public MealUpdateDtoValidator()
        {
            Include(new MealBaseDtoValidator());
        }
    }
}

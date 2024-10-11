using FluentValidation;

namespace FitnessPal.Application.DTOs.MealItemDTOs.Validators
{
    public class MealItemCreateDtoValidator : AbstractValidator<MealItemCreateDto>
    {
        public MealItemCreateDtoValidator()
        {
            Include(new MealItemBaseDtoValidator());
        }
    }
}

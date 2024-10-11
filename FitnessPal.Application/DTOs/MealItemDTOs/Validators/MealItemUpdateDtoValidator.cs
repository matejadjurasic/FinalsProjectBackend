using FluentValidation;

namespace FitnessPal.Application.DTOs.MealItemDTOs.Validators
{
    public class MealItemUpdateDtoValidator : AbstractValidator<MealItemUpdateDto>
    {
        public MealItemUpdateDtoValidator()
        {
            Include(new MealItemBaseDtoValidator());
        }
    }
}

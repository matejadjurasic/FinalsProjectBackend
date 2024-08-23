using FitnessPalAPI.Models.DataTransferModels.MealItemTransferModels;
using FluentValidation;

namespace FitnessPalAPI.Validators.MealItemValidators
{
    public class MealItemUpdateDtoValidator : AbstractValidator<MealItemUpdateDto>
    {
        public MealItemUpdateDtoValidator()
        {
            Include(new MealItemBaseDtoValidator());
        }
    }
}

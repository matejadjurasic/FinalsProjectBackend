using FitnessPalAPI.Models.DataTransferModels.MealItemTransferModels;
using FluentValidation;

namespace FitnessPalAPI.Validators.MealItemValidators
{
    public class MealItemReadDtoValidator : AbstractValidator<MealItemReadDto>
    {
        public MealItemReadDtoValidator()
        {
            Include(new MealItemBaseDtoValidator());
        }
    }
}

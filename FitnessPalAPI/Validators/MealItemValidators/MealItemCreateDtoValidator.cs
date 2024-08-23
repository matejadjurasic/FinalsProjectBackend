using FitnessPalAPI.Models.DataTransferModels.MealItemTransferModels;
using FluentValidation;

namespace FitnessPalAPI.Validators.MealItemValidators
{
    public class MealItemCreateDtoValidator : AbstractValidator<MealItemCreateDto>
    {
        public MealItemCreateDtoValidator()
        {
            Include(new MealItemBaseDtoValidator());
        }
    }
}

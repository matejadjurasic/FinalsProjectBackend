using FitnessPalAPI.Models.DataTransferModels.MealTransferModels;
using FluentValidation;

namespace FitnessPalAPI.Validators.MealValidators
{
    public class MealUpdateDtoValidator : AbstractValidator<MealUpdateDto>
    {
        public MealUpdateDtoValidator()
        {
            Include(new MealBaseDtoValidator());
        }
    }
}

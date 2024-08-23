using FitnessPalAPI.Models.DataTransferModels.MealTransferModels;
using FluentValidation;

namespace FitnessPalAPI.Validators.MealValidators
{
    public class MealReadDtoValidator : AbstractValidator<MealReadDto>
    {
        public MealReadDtoValidator()
        {
            Include(new MealBaseDtoValidator());
        }
    }
}

using FitnessPalAPI.Models.DataTransferModels.MealTransferModels;
using FluentValidation;

namespace FitnessPalAPI.Validators.MealValidators
{
    public class MealCreateDtoValidator : AbstractValidator<MealCreateDto>
    {
        public MealCreateDtoValidator()
        {
            Include(new MealBaseDtoValidator());
        }
    }
}

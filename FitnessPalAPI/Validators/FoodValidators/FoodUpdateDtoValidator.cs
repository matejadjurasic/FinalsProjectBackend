using FitnessPalAPI.Models.DataTransferModels.FoodTransferModels;
using FluentValidation;

namespace FitnessPalAPI.Validators.FoodValidators
{
    public class FoodUpdateDtoValidator : AbstractValidator<FoodUpdateDto>
    {
        public FoodUpdateDtoValidator()
        {
            Include(new FoodBaseDtoValidator());
        }
    }
}

using FitnessPalAPI.Models.DataTransferModels.FoodTransferModels;
using FluentValidation;

namespace FitnessPalAPI.Validators.FoodValidators
{
    public class FoodReadDtoValidator : AbstractValidator<FoodReadDto>
    {
        public FoodReadDtoValidator()
        {
            Include(new FoodBaseDtoValidator());
        }
    }
}

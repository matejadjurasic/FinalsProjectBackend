using FitnessPalAPI.Models.DataTransferModels.FoodTransferModels;
using FitnessPalAPI.Validators.DailyWeightValidators;
using FluentValidation;

namespace FitnessPalAPI.Validators.FoodValidators
{
    public class FoodCreateDtoValidator : AbstractValidator<FoodCreateDto>
    {
        public FoodCreateDtoValidator()
        {
            Include(new FoodBaseDtoValidator());
        }
    }
}

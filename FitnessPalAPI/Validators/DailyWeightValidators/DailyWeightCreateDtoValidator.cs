using FitnessPalAPI.Models.DataTransferModels.DailyWeightTransferModels;
using FluentValidation;

namespace FitnessPalAPI.Validators.DailyWeightValidators
{
    public class DailyWeightCreateDtoValidator : AbstractValidator<DailyWeightCreateDto>
    {
        public DailyWeightCreateDtoValidator()
        {
            Include(new DailyWeightBaseDtoValidator());
        }
    }
}

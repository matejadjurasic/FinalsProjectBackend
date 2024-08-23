using FitnessPalAPI.Models.DataTransferModels.DailyWeightTransferModels;
using FluentValidation;

namespace FitnessPalAPI.Validators.DailyWeightValidators
{
    public class DailyWeightUpdateDtoValidator : AbstractValidator<DailyWeightUpdateDto>
    {
        public DailyWeightUpdateDtoValidator()
        {
            Include(new DailyWeightBaseDtoValidator());
        }
    }
}

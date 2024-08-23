using FitnessPalAPI.Models.DataTransferModels.DailyWeightTransferModels;
using FluentValidation;

namespace FitnessPalAPI.Validators.DailyWeightValidators
{
    public class DailyWeightReadDtoValidator : AbstractValidator<DailyWeightReadDto>
    {
        public DailyWeightReadDtoValidator()
        {
            Include(new DailyWeightBaseDtoValidator());
        }
    }
}

using FitnessPalAPI.Models.DataTransferModels.GoalTransferModels;
using FluentValidation;

namespace FitnessPalAPI.Validators.GoalValidators
{
    public class GoalReadDtoValidator : AbstractValidator<GoalReadDto>
    {
        public GoalReadDtoValidator()
        {
            Include(new GoalBaseDtoValidator());
        }
    }
}

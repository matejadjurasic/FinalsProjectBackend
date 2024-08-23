using FitnessPalAPI.Models.DataTransferModels.GoalTransferModels;
using FluentValidation;

namespace FitnessPalAPI.Validators.GoalValidators
{
    public class GoalUpdateDtoValidator : AbstractValidator<GoalUpdateDto>
    {
        public GoalUpdateDtoValidator()
        {
            Include(new GoalBaseDtoValidator());
        }
    }
}

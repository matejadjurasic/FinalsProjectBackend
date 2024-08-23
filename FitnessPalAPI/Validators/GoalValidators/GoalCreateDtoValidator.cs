using FitnessPalAPI.Models.DataTransferModels.GoalTransferModels;
using FluentValidation;

namespace FitnessPalAPI.Validators.GoalValidators
{
    public class GoalCreateDtoValidator : AbstractValidator<GoalCreateDto>
    {
        public GoalCreateDtoValidator()
        {
            Include(new GoalBaseDtoValidator());
        }
    }
}

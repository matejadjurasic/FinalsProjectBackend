using FluentValidation;

namespace FitnessPal.Application.DTOs.GoalDTOs.Validators
{
    public class GoalUpdateDtoValidator : AbstractValidator<GoalUpdateDto>
    {
        public GoalUpdateDtoValidator()
        {
            Include(new GoalBaseDtoValidator());
        }
    }
}

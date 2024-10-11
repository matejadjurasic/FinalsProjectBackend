using FluentValidation;

namespace FitnessPal.Application.DTOs.GoalDTOs.Validators
{
    public class GoalCreateDtoValidator : AbstractValidator<GoalCreateDto>
    {
        public GoalCreateDtoValidator()
        {
            Include(new GoalBaseDtoValidator());
        }
    }
}

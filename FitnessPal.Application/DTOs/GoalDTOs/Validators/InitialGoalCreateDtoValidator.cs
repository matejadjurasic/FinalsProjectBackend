using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessPal.Application.DTOs.GoalDTOs.Validators
{
    public class InitialGoalCreateDtoValidator : AbstractValidator<InitialGoalCreateDto>
    {
        public InitialGoalCreateDtoValidator()
        {
            RuleFor(x => x.Weight)
                .GreaterThan(0).WithMessage("Weight must be greater than zero.");

            RuleFor(x => x.Height)
                .GreaterThan(0).WithMessage("Height must be greater than zero.");

            RuleFor(x => x.Age)
                .InclusiveBetween(10, 120).WithMessage("Age must be between 10 and 120.");

            RuleFor(x => x.Gender)
                .IsInEnum().WithMessage("Invalid gender.");

            RuleFor(x => x.ActivityLevel)
                .IsInEnum().WithMessage("Invalid activity level.");

            RuleFor(x => x.Type)
                .IsInEnum().WithMessage("Invalid goal type.");

            RuleFor(x => x.TargetWeight)
                .InclusiveBetween(1, 250).WithMessage("TargetWeight must be between 1 and 250 kg");
        }
    }
}

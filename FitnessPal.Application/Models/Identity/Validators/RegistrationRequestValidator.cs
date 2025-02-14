using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessPal.Application.Models.Identity.Validators
{
    public class RegistrationRequestValidator : AbstractValidator<RegistrationRequest>
    {
        public RegistrationRequestValidator()
        {
            RuleFor(x => x.Username)
               .NotEmpty()
               .WithMessage("Username is required.");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email is required!")
                .EmailAddress().WithMessage("Must be a valid email address");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Password is required")
                .MinimumLength(6).WithMessage("Password must be at least 6 characters long")
                .Matches("[A-Z]").WithMessage("Password must contain at least one uppercase letter")
                .Matches("[a-z]").WithMessage("Password must contain at least one lowercase letter")
                .Matches("[0-9]").WithMessage("Password must contain at least one number");

            RuleFor(x => x.Name)
               .NotEmpty()
               .WithMessage("Name is required.");

            RuleFor(x => x.Height)
                .GreaterThan(0)
                .WithMessage("Height must be greater than zero.");

            RuleFor(x => x.Weight)
                .GreaterThan(0)
                .WithMessage("Weight must be greater than zero.");

            RuleFor(x => x.Age)
                .InclusiveBetween(1, 120)
                .WithMessage("Age must be between 1 and 120.");

            RuleFor(x => x.Gender)
                .IsInEnum()
                .WithMessage("Gender must be a valid enum value.");
        }
    }
}

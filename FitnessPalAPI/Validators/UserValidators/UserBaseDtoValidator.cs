using FitnessPalAPI.Models.DataTransferModels.UserTransferModels;
using FluentValidation;

namespace FitnessPalAPI.Validators.UserValidators
{
    public class UserBaseDtoValidator : AbstractValidator<UserBaseDto>
    {
        public UserBaseDtoValidator()
        {
            RuleFor(x => x.Username)
                .NotEmpty()
                .WithMessage("Username is required.");

            RuleFor(x => x.Email)
                .NotEmpty()
                .EmailAddress()
                .WithMessage("A valid email address is required.");

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

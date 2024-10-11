using FluentValidation;

namespace FitnessPal.Application.DTOs.UserDTOs.Validators
{
    public class UserCreateDtoValidator : AbstractValidator<UserCreateDto>
    {
        public UserCreateDtoValidator()
        {
            Include(new UserBaseDtoValidator());
        }
    }
}

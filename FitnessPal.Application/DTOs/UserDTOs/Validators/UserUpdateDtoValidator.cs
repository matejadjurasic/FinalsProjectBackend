using FluentValidation;

namespace FitnessPal.Application.DTOs.UserDTOs.Validators
{
    public class UserUpdateDtoValidator : AbstractValidator<UserUpdateDto>
    {
        public UserUpdateDtoValidator()
        {
            Include(new UserBaseDtoValidator());
        }
    }
}

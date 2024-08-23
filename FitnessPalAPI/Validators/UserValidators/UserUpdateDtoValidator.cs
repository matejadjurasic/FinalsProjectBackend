using FitnessPalAPI.Models.DataTransferModels.UserTransferModels;
using FluentValidation;

namespace FitnessPalAPI.Validators.UserValidators
{
    public class UserUpdateDtoValidator : AbstractValidator<UserUpdateDto>
    {
        public UserUpdateDtoValidator()
        {
            Include(new UserBaseDtoValidator());
        }
    }
}

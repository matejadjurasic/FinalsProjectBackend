using FitnessPalAPI.Models.DataTransferModels.UserTransferModels;
using FluentValidation;

namespace FitnessPalAPI.Validators.UserValidators
{
    public class UserCreateDtoValidator : AbstractValidator<UserCreateDto>
    {
        public UserCreateDtoValidator()
        {
            Include(new UserBaseDtoValidator());
        }
    }
}

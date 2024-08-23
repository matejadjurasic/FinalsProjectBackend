using FitnessPalAPI.Models.DataTransferModels.UserTransferModels;
using FluentValidation;

namespace FitnessPalAPI.Validators.UserValidators
{
    public class UserReadDtoValidator : AbstractValidator<UserReadDto>
    {
        public UserReadDtoValidator()
        {
            Include(new UserBaseDtoValidator());
        }
    }
}

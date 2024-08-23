using FitnessPalAPI.Models.Enums;

namespace FitnessPalAPI.Models.DataTransferModels.UserTransferModels
{
    public class UserCreateDto : UserBaseDto
    {
        public string Password { get; set; } = string.Empty;
    }
}

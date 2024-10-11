namespace FitnessPal.Application.DTOs.UserDTOs
{
    public class UserCreateDto : UserBaseDto
    {
        public string Password { get; set; } = string.Empty;
    }
}

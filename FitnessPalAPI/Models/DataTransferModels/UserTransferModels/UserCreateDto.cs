using FitnessPalAPI.Models.Enums;

namespace FitnessPalAPI.Models.DataTransferModels.UserTransferModels
{
    public class UserCreateDto
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public double Height { get; set; }
        public double Weight { get; set; }
        public int Age { get; set; }
        public Gender Gender { get; set; }
    }
}

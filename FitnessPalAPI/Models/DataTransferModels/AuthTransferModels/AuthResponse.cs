using FitnessPalAPI.Models.Enums;

namespace FitnessPalAPI.Models.DataTransferModels.AuthTransferModels
{
    public class AuthResponse
    {
        public int Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public double Height { get; set; }
        public double Weight { get; set; }
        public int Age { get; set; }
        public Gender Gender { get; set; }
        public string Token { get; set; } = string.Empty;
    }
}

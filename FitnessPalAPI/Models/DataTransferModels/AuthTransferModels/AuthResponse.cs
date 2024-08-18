using FitnessPalAPI.Models.Enums;

namespace FitnessPalAPI.Models.DataTransferModels.AuthTransferModels
{
    public class AuthResponse
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public double Height { get; set; }
        public double Weight { get; set; }
        public int Age { get; set; }
        public Gender Gender { get; set; }
        public string Token { get; set; }
    }
}

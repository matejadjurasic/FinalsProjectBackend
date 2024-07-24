namespace FitnessPalAPI.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public int Height { get; set; }
        public int Weight { get; set; }
        public int Age { get; set; }
        public Gender Gender { get; set; }
        public Goal? Goal { get; set; }
        public ICollection<DailyWeight> DailyWeights { get; set; } = new List<DailyWeight>();
        public ICollection<Meal> Meals { get; set; } = new List<Meal>();
    }
}

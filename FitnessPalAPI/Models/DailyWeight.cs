namespace FitnessPalAPI.Models
{
    public class DailyWeight
    {
        public int Id { get; set; }
        public DateTime DateTime { get; set; }
        public int Weight { get; set; }
        public int UserId { get; set; }
        public User User { get; set; } = null!;
    }
}

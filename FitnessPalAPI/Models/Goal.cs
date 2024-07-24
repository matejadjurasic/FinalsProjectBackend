namespace FitnessPalAPI.Models
{
    public class Goal
    {
        public int Id { get; set; }
        public int TargetCalories { get; set; }
        public int TargetProtein { get; set; }
        public int TargetCarbs { get; set; }
        public int TargetFats { get; set; }
        public int TargetWeight { get; set; }
        public GoalType Type { get; set; }
        public int UserId { get; set; }
        public User User { get; set; } = null!;
    }
}

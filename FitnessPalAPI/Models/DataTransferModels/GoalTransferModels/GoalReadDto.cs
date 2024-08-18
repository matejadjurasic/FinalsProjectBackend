using FitnessPalAPI.Models.Enums;

namespace FitnessPalAPI.Models.DataTransferModels.GoalTransferModels
{
    public class GoalReadDto
    {
        public int Id { get; set; }
        public int TargetCalories { get; set; }
        public double TargetProtein { get; set; }
        public double TargetCarbs { get; set; }
        public double TargetFats { get; set; }
        public double TargetWeight { get; set; }
        public GoalType Type { get; set; }
        public int UserId { get; set; }
    }
}

using FitnessPalAPI.Models.Enums;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FitnessPalAPI.Models.DatabaseModels
{
    public class Goal
    {
        [Key]
        public int Id { get; set; }

        [Range(0, int.MaxValue)]
        public int TargetCalories { get; set; }

        [Range(0, double.MaxValue)]
        public double TargetProtein { get; set; }

        [Range(0, double.MaxValue)]
        public double TargetCarbs { get; set; }

        [Range(0, double.MaxValue)]
        public double TargetFats { get; set; }

        [Range(0, double.MaxValue)]
        public double TargetWeight { get; set; }

        [Required]
        public GoalType Type { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }
        public User? User { get; set; }
    }
}

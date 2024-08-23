using FitnessPalAPI.Models.Enums;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace FitnessPalAPI.Models.DatabaseModels
{
    public class User : IdentityUser<int>
    {
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;

        [Range(0, double.MaxValue)]
        public double Height { get; set; }

        [Range(0, double.MaxValue)]
        public double Weight { get; set; }

        [Range(0, 120)]
        public int Age { get; set; }

        [Required]
        public Gender Gender { get; set; }

        public ICollection<Goal> Goals { get; set; } = new List<Goal>();
        public ICollection<DailyWeight> DailyWeights { get; set; } = new List<DailyWeight>();
        public ICollection<Meal> Meals { get; set; } = new List<Meal>();
    }
}

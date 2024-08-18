using FitnessPalAPI.Models.Enums;
using Microsoft.AspNetCore.Identity;

namespace FitnessPalAPI.Models.DatabaseModels
{
    public class User : IdentityUser<int>
    {
        public string? Name { get; set; }
        public double Height { get; set; }
        public double Weight { get; set; }
        public int Age { get; set; }
        public Gender Gender { get; set; }
        public ICollection<Goal>? Goal { get; set; }
        public ICollection<DailyWeight> DailyWeights { get; set; } = new List<DailyWeight>();
        public ICollection<Meal> Meals { get; set; } = new List<Meal>();
    }
}

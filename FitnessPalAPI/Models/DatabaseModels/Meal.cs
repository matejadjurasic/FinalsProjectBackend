using FitnessPalAPI.Models.Enums;

namespace FitnessPalAPI.Models.DatabaseModels
{
    public class Meal
    {
        public int Id { get; set; }
        public int Calories { get; set; }
        public double Protein { get; set; }
        public double Carbs { get; set; }
        public double Fat { get; set; }
        public MealType MealType { get; set; }
        public DateTime DateTime { get; set; }
        public int UserId { get; set; }
        public User? User { get; set; }
        public ICollection<Food> Foods { get; set; } = new List<Food>();
    }
}

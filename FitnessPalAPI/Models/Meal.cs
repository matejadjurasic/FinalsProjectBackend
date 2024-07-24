namespace FitnessPalAPI.Models
{
    public class Meal
    {
        public int Id { get; set; }
        public int Calories { get; set; }
        public int Protein { get; set; }
        public int Carbs { get; set; }
        public int Fat {  get; set; }
        public MealType MealType { get; set; }
        public DateTime DateTime { get; set; }
        public int UserId { get; set; }
        public User User { get; set; } = null!;
        public ICollection<Food> Foods { get; set; } = new List<Food>();  
    }
}

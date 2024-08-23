using FitnessPalAPI.Models.Enums;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FitnessPalAPI.Models.DatabaseModels
{
    public class Meal
    {
        [Key]
        public int Id { get; set; }

        [Range(0, int.MaxValue)]
        public int Calories { get; set; }

        [Range(0, double.MaxValue)]
        public double Protein { get; set; }

        [Range(0, double.MaxValue)]
        public double Carbs { get; set; }

        [Range(0, double.MaxValue)]
        public double Fat { get; set; }

        [Required]
        public MealType MealType { get; set; }

        [Required]
        public DateTime DateTime { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }
        public User? User { get; set; }

        public ICollection<Food> Foods { get; set; } = new List<Food>();
    }
}

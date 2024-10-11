using FitnessPal.Domain.Enums;

namespace FitnessPal.Application.DTOs.MealDTOs
{
    public class MealBaseDto
    {
        public int Calories { get; set; }
        public double Protein { get; set; }
        public double Carbs { get; set; }
        public double Fat { get; set; }
        public MealType MealType { get; set; }
        public DateTime DateTime { get; set; }
    }
}

using FitnessPalAPI.Models.Enums;

namespace FitnessPalAPI.Models.DataTransferModels.MealTransferModels
{
    public class MealCreateDto
    {
        public int Calories { get; set; }
        public double Protein { get; set; }
        public double Carbs { get; set; }
        public double Fat { get; set; }
        public MealType MealType { get; set; }
        public DateTime DateTime { get; set; }
        public int UserId { get; set; }
    }
}

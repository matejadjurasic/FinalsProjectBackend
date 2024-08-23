using System.ComponentModel.DataAnnotations;

namespace FitnessPalAPI.Models.DatabaseModels
{
    public class Food
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(100)]
        public string Name { get; set; } = string.Empty;

        [MaxLength(500)]
        public string Description { get; set; } = string.Empty;

        [Range(0, int.MaxValue)]
        public int Calories { get; set; }

        [Range(0, double.MaxValue)]
        public double Protein { get; set; }

        [Range(0, double.MaxValue)]
        public double Carbs { get; set; }

        [Range(0, double.MaxValue)]
        public double Fat { get; set; }
    }
}

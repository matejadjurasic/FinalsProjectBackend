using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FitnessPalAPI.Models.DatabaseModels
{
    public class DailyWeight
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime DateTime { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Weight must be a positive number.")]
        public double Weight { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }
        public User? User { get; set; }
    }
}

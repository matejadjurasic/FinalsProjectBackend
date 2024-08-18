using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FitnessPalAPI.Models.DatabaseModels
{
    public class DailyWeight
    {
        public int Id { get; set; }
        public DateTime DateTime { get; set; }
        public double Weight { get; set; }
        public int UserId { get; set; }
        public User? User { get; set; }
    }
}

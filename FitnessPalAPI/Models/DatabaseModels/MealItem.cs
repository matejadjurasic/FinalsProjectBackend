using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FitnessPalAPI.Models.DatabaseModels
{
    public class MealItem
    {
        public int MealId { get; set; }
        public int FoodId { get; set; }

        [Range(0, double.MaxValue)]
        public double Amount { get; set; }
    }
}

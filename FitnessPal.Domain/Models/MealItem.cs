using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessPal.Domain.Models
{
    public class MealItem
    {
        public int MealId { get; set; }
        public Meal? Meal { get; set; }
        public int IngredientId { get; set; }
        public Ingredient? Ingredient { get; set; }
        public double Amount { get; set; }
    }
}

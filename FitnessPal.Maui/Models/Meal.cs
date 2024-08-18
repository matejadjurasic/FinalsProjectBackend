using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessPal.Maui.Models
{
    public class Meal
    {
        public int Id { get; set; }
        public int Calories { get; set; }
        public int Protein { get; set; }
        public int Carbs { get; set; }
        public int Fat { get; set; }
        public MealType MealType { get; set; }
        public DateTime DateTime { get; set; }
        public ICollection<Food> Foods { get; set; } = new List<Food>();
    }
}

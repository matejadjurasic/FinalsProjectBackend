using FitnessPal.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessPal.Domain.Models
{
    public class Ingredient : BaseDomainEntity
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int Calories { get; set; }
        public double Protein { get; set; }
        public double Carbs { get; set; }
        public double Fat { get; set; }
        public ICollection<Meal> Meals { get; set; } = new List<Meal>();
        public ICollection<MealItem> MealItems { get; set; } = new List<MealItem>();
    }
}

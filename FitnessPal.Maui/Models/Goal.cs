using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessPal.Maui.Models
{
    internal class Goal
    {
        public int Id { get; set; }
        public GoalType GoalType { get; set; }
        public int TargetCalories { get; set; }
        public int TargetProtein { get; set; }
        public int TargetCarbs { get; set; }
        public int TargetFat { get; set; }

    }
}

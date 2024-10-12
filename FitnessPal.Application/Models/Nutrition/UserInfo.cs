using FitnessPal.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessPal.Application.Models.Nutrition
{
    public class UserInfo
    {
        public double Weight { get; set; }
        public double Height { get; set; }
        public int Age { get; set; }
        public Gender Gender { get; set; }
        public ActivityLevel ActivityLevel { get; set; }
        public GoalType GoalType { get; set; }
    }
}

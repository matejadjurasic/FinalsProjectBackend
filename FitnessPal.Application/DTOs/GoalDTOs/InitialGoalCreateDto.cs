using FitnessPal.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessPal.Application.DTOs.GoalDTOs
{
    public class InitialGoalCreateDto
    {
        public double Weight { get; set; }
        public double Height { get; set; }
        public int Age { get; set; }
        public Gender Gender { get; set; }
        public ActivityLevel ActivityLevel { get; set; }
        public GoalType Type { get; set; }
        public double? TargetWeight { get; set; }
    }
}

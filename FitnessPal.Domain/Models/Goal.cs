using FitnessPal.Domain.Common;
using FitnessPal.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessPal.Domain.Models
{
    public class Goal : BaseDomainEntity
    {
        public int TargetCalories { get; set; }
        public double TargetProtein { get; set; }
        public double TargetCarbs { get; set; }
        public double TargetFats { get; set; }
        public double TargetWeight { get; set; }
        public GoalType Type { get; set; }
        public int UserId { get; set; }
        public User? User { get; set; }
    }
}

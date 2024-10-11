using FitnessPal.Domain.Enums;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessPal.Domain.Models
{
    public class User : IdentityUser<int>
    {
        public string Name { get; set; } = string.Empty;
        public double Height { get; set; }
        public double Weight { get; set; }
        public int Age { get; set; }
        public Gender Gender { get; set; }
        public ICollection<Goal> Goals { get; set; } = new List<Goal>();
        public ICollection<DailyWeight> DailyWeights { get; set; } = new List<DailyWeight>();
        public ICollection<Meal> Meals { get; set; } = new List<Meal>();
        public virtual ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();
    }
}

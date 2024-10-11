using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FitnessPal.Domain.Common;

namespace FitnessPal.Domain.Models
{
    public class DailyWeight : BaseDomainEntity
    {
        public DateTime DateTime { get; set; }
        public double Weight { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }
        public User? User { get; set; }
    }
}

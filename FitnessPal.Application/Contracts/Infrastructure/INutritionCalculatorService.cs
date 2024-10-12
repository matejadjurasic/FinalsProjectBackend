using FitnessPal.Application.Models.Nutrition;
using FitnessPal.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessPal.Application.Contracts.Infrastructure
{
    public interface INutritionCalculatorService
    {
        NutritionGoals CalculateGoals(UserInfo userInfo);
    }
}

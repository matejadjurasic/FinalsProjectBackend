using FitnessPal.Application.Contracts.Infrastructure;
using FitnessPal.Application.Models.Nutrition;
using FitnessPal.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessPal.Infrastructure.Services
{
    public class NutritionCalculatorService : INutritionCalculatorService
    {
        public NutritionGoals CalculateGoals(UserInfo userInfo)
        {
            double bmr = CalculateBMR(userInfo);
            double tdee = CalculateTDEE(bmr, userInfo.ActivityLevel);
            double adjustedCalories = AdjustCaloriesForGoal(tdee, userInfo.GoalType);

            double proteinCalories = adjustedCalories * 0.30; 
            double carbsCalories = adjustedCalories * 0.40;   
            double fatsCalories = adjustedCalories * 0.30;   

            double proteinGrams = proteinCalories / 4;
            double carbsGrams = carbsCalories / 4;
            double fatsGrams = fatsCalories / 9;

            return new NutritionGoals
            {
                TargetCalories = (int)adjustedCalories,
                TargetProtein = proteinGrams,
                TargetCarbs = carbsGrams,
                TargetFats = fatsGrams
            };
        }

        private double CalculateBMR(UserInfo userInfo)
        {
            if (userInfo.Gender == Gender.Male)
            {
                return (10 * userInfo.Weight) + (6.25 * userInfo.Height) - (5 * userInfo.Age) + 5;
            }
            else if (userInfo.Gender == Gender.Female)
            {
                return (10 * userInfo.Weight) + (6.25 * userInfo.Height) - (5 * userInfo.Age) - 161;
            }
            else
            {
                return (10 * userInfo.Weight) + (6.25 * userInfo.Height) - (5 * userInfo.Age);
            }
        }

        private double CalculateTDEE(double bmr, ActivityLevel activityLevel)
        {
            double activityFactor = activityLevel switch
            {
                ActivityLevel.Sedentary => 1.2,
                ActivityLevel.LightlyActive => 1.375,
                ActivityLevel.ModeratelyActive => 1.55,
                ActivityLevel.VeryActive => 1.725,
                ActivityLevel.ExtraActive => 1.9,
                _ => 1.2,
            };
            return bmr * activityFactor;
        }

        private double AdjustCaloriesForGoal(double tdee, GoalType goalType)
        {
            double adjustedCalories = goalType switch
            {
                GoalType.WeightLoss => tdee - 500,
                GoalType.Maintenance => tdee,
                GoalType.WeightGain => tdee + 500,
                _ => tdee,
            };

            if (adjustedCalories < 1200)
            {
                adjustedCalories = 1200; 
            }

            return adjustedCalories;
        }
    }
}

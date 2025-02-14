using FitnessPal.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessPal.Application.Contracts.Persistence
{
    public interface IMealItemRepository : IGenericRepository<MealItem>
    {
        Task<MealItem> GetMealItem(int mealId, int IngredientId);
        Task<List<MealItem>> GetMealItems(int mealId);
        Task<bool> MealItemExists(int mealId, int ingredientId);
    }
}

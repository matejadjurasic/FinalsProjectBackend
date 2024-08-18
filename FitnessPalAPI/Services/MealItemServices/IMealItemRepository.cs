using FitnessPalAPI.Models.DatabaseModels;

namespace FitnessPalAPI.Services.MealItemServices
{
    public interface IMealItemRepository
    {
        Task<List<MealItem>> GetAllAsync();
        Task<MealItem> GetByIdAsync(int mealId,int foodId);
        Task AddAsync(MealItem mealItem);
        Task UpdateAsync(MealItem mealItem);
        Task DeleteAsync(MealItem mealItem);
        Task<bool> ExistsAsync(int id);
    }
}

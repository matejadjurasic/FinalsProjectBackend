using FitnessPalAPI.Models.DatabaseModels;

namespace FitnessPalAPI.Services.MealServices
{
    public interface IMealRepository
    {
        Task<IEnumerable<Meal>> GetAllByUserIdAsync(int userId);
        Task<Meal> GetByIdAndUserIdAsync(int mealId, int userId);
        Task AddAsync(Meal meal);
        Task UpdateAsync(Meal meal);
        Task DeleteAsync(Meal meal);
        Task<bool> ExistsAsync(int mealId, int userId);
    }
}

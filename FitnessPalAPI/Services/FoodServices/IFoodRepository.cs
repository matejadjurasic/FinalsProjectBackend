using FitnessPalAPI.Models.DatabaseModels;

namespace FitnessPalAPI.Services.FoodServices
{
    public interface IFoodRepository
    {
        Task<IEnumerable<Food>> GetAllAsync();
        Task<Food> GetByIdAsync(int foodId);
        Task AddAsync(Food food);
        Task UpdateAsync(Food food);
        Task DeleteAsync(Food food);
    }
}

using FitnessPalAPI.Models.DataTransferModels.GoalTransferModels;
using FitnessPalAPI.Models.DataTransferModels.MealTransferModels;

namespace FitnessPalAPI.Services.MealServices
{
    public interface IMealService
    {
        Task<IEnumerable<MealReadDto>> GetAllMealsAsync(int userId);
        Task<MealReadDto> GetMealByIdAsync(int userId, int mealId);
        Task<MealReadDto> CreateMealAsync(int userId, MealCreateDto mealDto);
        Task<MealReadDto> UpdateMealAsync(int userId, int mealId, MealUpdateDto mealDto);
        Task<bool> DeleteMealAsync(int userId, int mealId);
    }
}

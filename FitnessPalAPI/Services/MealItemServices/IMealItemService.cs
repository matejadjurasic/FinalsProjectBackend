using FitnessPalAPI.Models.DataTransferModels.MealItemTransferModels;

namespace FitnessPalAPI.Services.MealItemServices
{
    public interface IMealItemService
    {
        Task<IEnumerable<MealItemReadDto>> GetAllMealItemsAsync();
        Task<MealItemReadDto> GetMealItemByIdAsync(int mealId, int foodId);
        Task<MealItemReadDto> CreateMealItemAsync(MealItemCreateDto mealItemDto);
        Task<MealItemReadDto> UpdateMealItemAsync(int mealId,int foodId, MealItemUpdateDto mealItemDto);
        Task DeleteMealItemAsync(int mealId,int foodId);
    }
}

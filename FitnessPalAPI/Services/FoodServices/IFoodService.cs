using FitnessPalAPI.Models.DataTransferModels.FoodTransferModels;

namespace FitnessPalAPI.Services.FoodServices
{
    public interface IFoodService
    {
        Task<IEnumerable<FoodReadDto>> GetAllFoodsAsync();
        Task<FoodReadDto> GetFoodByIdAsync(int foodId);
        Task<FoodReadDto> CreateFoodAsync(FoodCreateDto foodDto);
        Task<FoodReadDto> UpdateFoodAsync(int foodId, FoodUpdateDto foodDto);
        Task DeleteFoodAsync(int foodId);
    }
}

using FitnessPalAPI.Models.DatabaseModels;

namespace FitnessPalAPI.Services.DailyWeightServices
{
    public interface IDailyWeightRepository
    {
        Task<IEnumerable<DailyWeight>> GetAllWeightsAsync(int userId);
        Task<DailyWeight> GetWeightByIdAsync(int userId, int id);
        Task<bool> WeightExistsAsync(int userId, DateTime date);
        Task AddWeightAsync(DailyWeight dailyWeight);
        Task<bool> UpdateWeightAsync(DailyWeight dailyWeight);
        Task<bool> DeleteWeightAsync(int userId, int id);
    }
}

using FitnessPalAPI.Models;
using FitnessPalAPI.Models.DataTransferModels.DailyWeightTransferModels;

namespace FitnessPalAPI.Services.DailyWeightServices
{
    public interface IDailyWeightService
    {
        Task<IEnumerable<DailyWeightReadDto>> GetAllWeightsAsync(int userId);
        Task<DailyWeightReadDto> GetWeightByIdAsync(int userId, int weightId);
        Task<DailyWeightReadDto> CreateWeightAsync(int userId, DailyWeightCreateDto createDto);
        Task<DailyWeightReadDto> UpdateWeightAsync(int userId, int weightId, DailyWeightUpdateDto updateDto);
        Task DeleteWeightAsync(int userId, int weightId);
    }
}

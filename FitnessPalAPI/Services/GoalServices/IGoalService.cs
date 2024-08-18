using FitnessPalAPI.Models.DataTransferModels.GoalTransferModels;

namespace FitnessPalAPI.Services.GoalServices
{
    public interface IGoalService
    {
        Task<IEnumerable<GoalReadDto>> GetGoalsByUserIdAsync(int userId);
        Task<GoalReadDto> GetGoalByIdAsync(int userId, int goalId);
        Task<GoalReadDto> CreateGoalAsync(int userId, GoalCreateDto createDto);
        Task<GoalReadDto> UpdateGoalAsync(int userId, int goalId, GoalUpdateDto updateDto);
        Task<bool> DeleteGoalAsync(int userId, int goalId);
    }
}

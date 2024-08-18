using FitnessPalAPI.Models.DatabaseModels;

namespace FitnessPalAPI.Services.GoalServices
{
    public interface IGoalRepository
    {
        Task<IEnumerable<Goal>> GetAllAsync(int userId);
        Task<Goal> GetByIdAsync(int userId, int goalId);
        Task AddAsync(Goal goal);
        Task UpdateAsync(Goal goal);
        Task DeleteAsync(Goal goal);
        Task<bool> ExistsAsync(int userId);
    }
}

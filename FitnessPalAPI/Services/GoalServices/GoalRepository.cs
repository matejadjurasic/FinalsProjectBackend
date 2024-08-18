using FitnessPalAPI.Data;
using FitnessPalAPI.Models.DatabaseModels;
using Microsoft.EntityFrameworkCore;

namespace FitnessPalAPI.Services.GoalServices
{
    public class GoalRepository : IGoalRepository
    {
        private readonly AppDbContext _context;

        public GoalRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Goal>> GetAllAsync(int userId)
        {
            return await _context.Goals
                                 .Where(g => g.UserId == userId)
                                 .ToListAsync();
        }

        public async Task<Goal> GetByIdAsync(int userId, int goalId)
        {
            return await _context.Goals
                                 .FirstOrDefaultAsync(g => g.Id == goalId && g.UserId == userId);
        }

        public async Task AddAsync(Goal goal)
        {
            _context.Goals.Add(goal);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Goal goal)
        {
            _context.Entry(goal).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Goal goal)
        {
            _context.Goals.Remove(goal);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> ExistsAsync(int userId)
        {
            return await _context.Goals.AnyAsync(g => g.UserId == userId);
        }
    }
}

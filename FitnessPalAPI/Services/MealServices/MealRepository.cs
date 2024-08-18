using FitnessPalAPI.Data;
using FitnessPalAPI.Models.DatabaseModels;
using Microsoft.EntityFrameworkCore;

namespace FitnessPalAPI.Services.MealServices
{
    public class MealRepository : IMealRepository
    {
        private readonly AppDbContext _context;

        public MealRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Meal>> GetAllByUserIdAsync(int userId)
        {
            return await _context.Meals
                                 .Where(m => m.UserId == userId)
                                 .ToListAsync();
        }

        public async Task<Meal> GetByIdAndUserIdAsync(int mealId, int userId)
        {
            return await _context.Meals
                                 .FirstOrDefaultAsync(m => m.Id == mealId && m.UserId == userId);
        }

        public async Task AddAsync(Meal meal)
        {
            _context.Meals.Add(meal);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Meal meal)
        {
            _context.Entry(meal).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Meal meal)
        {
            _context.Meals.Remove(meal);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> ExistsAsync(int mealId, int userId)
        {
            return await _context.Meals.AnyAsync(m => m.Id == mealId && m.UserId == userId);
        }
    }
}

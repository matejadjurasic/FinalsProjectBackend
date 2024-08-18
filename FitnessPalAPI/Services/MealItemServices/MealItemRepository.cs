using FitnessPalAPI.Data;
using FitnessPalAPI.Models.DatabaseModels;
using Microsoft.EntityFrameworkCore;

namespace FitnessPalAPI.Services.MealItemServices
{
    public class MealItemRepository : IMealItemRepository
    {
        private readonly AppDbContext _context;

        public MealItemRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<MealItem>> GetAllAsync()
        {
            return await _context.MealItems.ToListAsync();
        }

        public async Task<MealItem> GetByIdAsync(int mealId,int foodId)
        {
            return await _context.MealItems.FindAsync(mealId,foodId);
        }

        public async Task AddAsync(MealItem mealItem)
        {
            _context.MealItems.Add(mealItem);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(MealItem mealItem)
        {
            _context.Entry(mealItem).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(MealItem mealItem)
        {
            _context.MealItems.Remove(mealItem);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.MealItems.AnyAsync(e => e.FoodId == id);
        }
    }
}

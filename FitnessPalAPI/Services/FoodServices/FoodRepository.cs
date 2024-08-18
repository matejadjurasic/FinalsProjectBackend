using FitnessPalAPI.Data;
using FitnessPalAPI.Models.DatabaseModels;
using Microsoft.EntityFrameworkCore;

namespace FitnessPalAPI.Services.FoodServices
{
    public class FoodRepository : IFoodRepository
    {
        private readonly AppDbContext _context;

        public FoodRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Food>> GetAllAsync()
        {
            return await _context.Foods.ToListAsync();
        }

        public async Task<Food> GetByIdAsync(int foodId)
        {
            return await _context.Foods.FindAsync(foodId);
        }

        public async Task AddAsync(Food food)
        {
            _context.Foods.Add(food);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Food food)
        {
            _context.Entry(food).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Food food)
        {
            _context.Foods.Remove(food);
            await _context.SaveChangesAsync();
        }
    }
}

using FitnessPalAPI.Data;
using FitnessPalAPI.Models.DatabaseModels;
using Microsoft.EntityFrameworkCore;

namespace FitnessPalAPI.Services.DailyWeightServices
{
    public class DailyWeightRepository : IDailyWeightRepository
    {
        private readonly AppDbContext _context;

        public DailyWeightRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<DailyWeight>> GetAllWeightsAsync(int userId)
        {
            return await _context.DailyWeights
                                 .Where(dw => dw.UserId == userId)
                                 .ToListAsync();
        }

        public async Task<DailyWeight> GetWeightByIdAsync(int userId, int id)
        {
            return await _context.DailyWeights
                                 .FirstOrDefaultAsync(dw => dw.UserId == userId && dw.Id == id);
        }

        public async Task<bool> WeightExistsAsync(int userId, DateTime date)
        {
            return await _context.DailyWeights
                                 .AnyAsync(dw => dw.UserId == userId && dw.DateTime.Date == date.Date);
        }

        public async Task AddWeightAsync(DailyWeight dailyWeight)
        {
            _context.DailyWeights.Add(dailyWeight);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> UpdateWeightAsync(DailyWeight dailyWeight)
        {
            _context.Entry(dailyWeight).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await _context.DailyWeights.AnyAsync(dw => dw.Id == dailyWeight.Id))
                {
                    return false;
                }
                throw;
            }
        }
        public async Task DeleteWeightAsync(DailyWeight dailyWeight)
        {
            _context.DailyWeights.Remove(dailyWeight);
            await _context.SaveChangesAsync();
        }
    }
}

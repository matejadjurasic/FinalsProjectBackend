using FitnessPal.Application.Contracts.Persistence;
using FitnessPal.Application.Exceptions;
using FitnessPal.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessPal.Persistence.Repositories
{
    public class DailyWeightRepository : GenericRepository<DailyWeight>, IDailyWeightRepository
    {
        private readonly AppDbContext _appDbContext;

        public DailyWeightRepository(AppDbContext appDbContext) : base(appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<List<DailyWeight>> GetDailyWeightsByUserIdAsync(int userId)
        {
            return await _appDbContext.DailyWeights
                .Where(p => p.UserId == userId)
                .ToListAsync();
        }

        public async Task<DailyWeight> GetDailyWeightByDateAsync(DateTime date, int userId)
        {
            var dailyWeight = await _appDbContext.DailyWeights
                                    .Where(p => p.DateTime.Date == date.Date && p.UserId == userId)
                                    .FirstOrDefaultAsync();

            if (dailyWeight == null)
                throw new NotFoundException(nameof(DailyWeight), date);

            return dailyWeight;
        }
    }
}

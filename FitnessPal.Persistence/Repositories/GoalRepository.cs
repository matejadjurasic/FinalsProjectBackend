using FitnessPal.Application.Contracts.Persistence;
using FitnessPal.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessPal.Persistence.Repositories
{
    public class GoalRepository : GenericRepository<Goal>, IGoalRepository
    {
        private readonly AppDbContext _appDbContext;

        public GoalRepository(AppDbContext appDbContext) : base(appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<List<Goal>> GetGoalsByUserIdAsync(int userId)
        {
            return await _appDbContext.Goals
                .Where(p => p.UserId == userId)
                .ToListAsync();
        }
    }
}

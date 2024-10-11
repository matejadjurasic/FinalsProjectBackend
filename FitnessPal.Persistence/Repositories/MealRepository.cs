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
    public class MealRepository : GenericRepository<Meal>, IMealRepository
    {
        private readonly AppDbContext _appDbContext;

        public MealRepository(AppDbContext appDbContext) : base(appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<List<Meal>> GetMealsByDate(DateTime date, int userId)
        {
            return await _appDbContext.Meals
                            .Where(p => p.DateTime.Date == date.Date && p.UserId == userId)
                            .ToListAsync();
        }
    }
}

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
    public class MealItemRepository : GenericRepository<MealItem>, IMealItemRepository
    {
        private readonly AppDbContext _appDbContext;

        public MealItemRepository(AppDbContext appDbContext) : base(appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<MealItem> GetMealItem(int mealId, int IngredientId)
        {
            var mealItem = await _appDbContext.MealItems
                .FindAsync(mealId, IngredientId);

            if(mealItem == null)
                throw new NotFoundException(nameof(MealItem),IngredientId);

            return mealItem;
        }

        public async Task<List<MealItem>> GetMealItems(int mealId)
        {
            var mealItems = await _appDbContext.MealItems
                .Where(m => m.MealId == mealId)
                .ToListAsync();

            return mealItems;
        }

        public async Task<bool> MealItemExists(int mealId, int ingredientId)
        {
            return await _appDbContext.MealItems
                .AnyAsync(m => m.MealId == mealId && m.IngredientId == ingredientId);
        }
    }
}

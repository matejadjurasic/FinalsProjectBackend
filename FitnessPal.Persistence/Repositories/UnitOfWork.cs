using FitnessPal.Application.Contracts.Persistence;
using FitnessPal.Domain.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessPal.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _appDbContext;
        private readonly UserManager<User> _userManager;

        private IMealRepository _mealRepository;
        private IMealItemRepository _mealItemRepository;
        private IUserRepository _userRepository;
        private IIngredientRepository _ingredientRepository;
        private IGoalRepository _goalRepository;
        private IDailyWeightRepository _dailyWeightRepository;

        public UnitOfWork(AppDbContext appDbContext, UserManager<User> userManager)
        {
            _appDbContext = appDbContext;
            _userManager = userManager;
        }

        public IIngredientRepository IngredientRepository => 
            _ingredientRepository ??= new IngredientRepository(_appDbContext);
        public IMealRepository MealRepository =>
            _mealRepository ??= new MealRepository(_appDbContext);
        public IMealItemRepository MealItemRepository =>
            _mealItemRepository ??= new MealItemRepository(_appDbContext);
        public IUserRepository UserRepository =>
            _userRepository ??= new UserRepository(_appDbContext,_userManager);
        public IGoalRepository GoalRepository =>
            _goalRepository ??= new GoalRepository(_appDbContext);
        public IDailyWeightRepository DailyWeightRepository =>
            _dailyWeightRepository ??= new DailyWeightRepository(_appDbContext);

        public void Dispose()
        {
            _appDbContext.Dispose();
            GC.SuppressFinalize(this);
        }

        public async Task Save()
        {
            await _appDbContext.SaveChangesAsync();
        }
    }
}

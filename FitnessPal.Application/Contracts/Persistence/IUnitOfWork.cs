using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessPal.Application.Contracts.Persistence
{
    public interface IUnitOfWork : IDisposable
    {
        IDailyWeightRepository DailyWeightRepository { get; }
        IGoalRepository GoalRepository { get; }
        IIngredientRepository IngredientRepository { get; }
        IMealItemRepository MealItemRepository { get; }
        IMealRepository MealRepository { get; }
        IUserRepository UserRepository { get; }
        Task Save();
    }
}

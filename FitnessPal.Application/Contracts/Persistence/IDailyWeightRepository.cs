using FitnessPal.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessPal.Application.Contracts.Persistence
{
    public interface IDailyWeightRepository : IGenericRepository<DailyWeight>
    {
        Task<List<DailyWeight>> GetDailyWeightsByUserIdAsync(int userId);
        Task<DailyWeight> GetDailyWeightByDateAsync(DateTime date, int userId);
    }
}

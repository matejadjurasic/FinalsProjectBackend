using FitnessPal.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessPal.Application.Contracts.Persistence
{
    public interface IIngredientRepository : IGenericRepository<Ingredient>
    {
    }
}

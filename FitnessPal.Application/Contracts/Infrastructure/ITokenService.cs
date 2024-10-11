using FitnessPal.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessPal.Application.Contracts.Infrastructure
{
    public interface ITokenService
    {
        Task<string> GenerateToken(User user);
    }
}

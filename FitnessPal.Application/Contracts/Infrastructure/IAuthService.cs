using FitnessPal.Application.Models.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessPal.Application.Contracts.Infrastructure
{
    public interface IAuthService
    {
        Task<AuthResponse> Login(AuthRequest request);
        Task Register(RegistrationRequest request);
    }
}

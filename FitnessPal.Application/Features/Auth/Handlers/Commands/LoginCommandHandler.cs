using FitnessPal.Application.Contracts.Infrastructure;
using FitnessPal.Application.Features.Auth.Requests.Commands;
using FitnessPal.Application.Models.Identity;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessPal.Application.Features.Auth.Handlers.Commands
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand, AuthResponse>
    {
        private readonly IAuthService _authService;

        public LoginCommandHandler(IAuthService authService)
        {
            _authService = authService;
        }

        public async Task<AuthResponse> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var authResponse = await _authService.Login(request.authRequest!);
            return authResponse;
        }
    }
}

using FitnessPal.Application.Contracts.Infrastructure;
using FitnessPal.Application.Features.Auth.Requests.Commands;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessPal.Application.Features.Auth.Handlers.Commands
{
    public class RegisterCommandHandler : IRequestHandler<RegisterCommand>
    {
        private readonly IAuthService _authService;

        public RegisterCommandHandler(IAuthService authService)
        {
            _authService = authService;
        }

        public async Task Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            await _authService.Register(request.RegistrationRequest!);
        }
    }
}

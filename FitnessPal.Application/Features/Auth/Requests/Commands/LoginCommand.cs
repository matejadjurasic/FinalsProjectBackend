using FitnessPal.Application.Models.Identity;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessPal.Application.Features.Auth.Requests.Commands
{
    public class LoginCommand : IRequest<AuthResponse>
    {
        public AuthRequest? authRequest {  get; set; }
    }
}

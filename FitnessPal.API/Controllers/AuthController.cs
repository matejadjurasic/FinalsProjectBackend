using FitnessPal.Application.Contracts.Infrastructure;
using FitnessPal.Application.Features.Auth.Requests.Commands;
using FitnessPal.Application.Models.Identity;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FitnessPal.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;


        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegistrationRequest model)
        {
            await _mediator.Send(new RegisterCommand { RegistrationRequest = model });
            return Ok("User registered successfully");
        }


        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] AuthRequest model)
        {
            var authResponse = await _mediator.Send(new LoginCommand { authRequest = model });
            return Ok(authResponse);
        }
    }
}

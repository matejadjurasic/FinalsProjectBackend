using FitnessPal.Application.DTOs.GoalDTOs;
using FitnessPal.Application.Features.Goals.Requests.Commands;
using FitnessPal.Application.Features.Goals.Requests.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FitnessPal.API.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class GoalsController : BaseController
    {
        private readonly IMediator _mediator;

        public GoalsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/Goals
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GoalReadDto>>> GetGoals()
        {
            var goals = await _mediator.Send(new GetGoalListRequest { UserId = CurrentUserId });
            return Ok(goals);
        }

        // GET: api/Goals/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GoalReadDto>> GetGoal(int id)
        {
            var goal = await _mediator.Send(new GetGoalRequest { Id = id, UserId = CurrentUserId });
            return Ok(goal);
        }

        // PUT: api/Goals/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGoal(int id, [FromBody] GoalUpdateDto goal)
        {
            await _mediator.Send(new UpdateGoalCommand { Id = id, GoalUpdateDto = goal, UserId = CurrentUserId });
            return NoContent();
        }

        // POST: api/Goals
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult> PostGoal([FromBody] GoalCreateDto goal)
        {
            var response = await _mediator.Send(new CreateGoalCommand { GoalCreateDto = goal, UserId = CurrentUserId });
            return Ok(response);
        }

        // DELETE: api/Goals/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGoal(int id)
        {
            await _mediator.Send(new DeleteGoalCommand { Id = id, UserId = CurrentUserId });
            return NoContent();
        }
    }
}

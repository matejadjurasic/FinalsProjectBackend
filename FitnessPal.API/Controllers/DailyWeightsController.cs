using FitnessPal.Application.DTOs.DailyWeightDTOs;
using FitnessPal.Application.Features.DailyWeights.Requests.Commands;
using FitnessPal.Application.Features.DailyWeights.Requests.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FitnessPal.API.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class DailyWeightsController : BaseController
    {
        private readonly IMediator _mediator;

        public DailyWeightsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/DailyWeights
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DailyWeightReadDto>>> GetDailyWeights()
        {
            var dailyWeights = await _mediator.Send(new GetDailyWeightListRequest { UserId = CurrentUserId});
            return Ok(dailyWeights);
        }

        // GET: api/DailyWeights/date
        [HttpGet("date")]
        public async Task<ActionResult<DailyWeightReadDto>> GetDailyWeightByDate([FromQuery] DateTime date)
        {
            var dailyWeight = await _mediator.Send(new GetDailyWeightByDateRequest { UserId = CurrentUserId , Date = date});
            return Ok(dailyWeight);
        }

        // GET: api/DailyWeights/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DailyWeightReadDto>> GetDailyWeight(int id)
        {
            var dailyWeight = await _mediator.Send(new GetDailyWeightRequest { Id = id, UserId = CurrentUserId });
            return Ok(dailyWeight);
        }

        // PUT: api/DailyWeights/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDailyWeight(int id, [FromBody] DailyWeightUpdateDto dailyWeight)
        {
            await _mediator.Send(new UpdateDailyWeightCommand { Id = id, DailyWeightUpdateDto = dailyWeight, UserId = CurrentUserId });
            return NoContent();
        }

        // POST: api/DailyWights
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult> PostDailyWeight([FromBody] DailyWeightCreateDto dailyWeight)
        {
            var response = await _mediator.Send(new CreateDailyWeightCommand { DailyWeightCreateDto = dailyWeight, UserId = CurrentUserId });
            return Ok(response);
        }

        // DELETE: api/DailyWeights/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDailyWeight(int id)
        {
            await _mediator.Send(new DeleteDailyWeightCommand { Id = id, UserId = CurrentUserId });
            return NoContent();
        }
    }
}

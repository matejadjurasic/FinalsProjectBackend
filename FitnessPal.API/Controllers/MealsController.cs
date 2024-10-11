using FitnessPal.Application.DTOs.MealDTOs;
using FitnessPal.Application.Features.Meals.Requests.Commands;
using FitnessPal.Application.Features.Meals.Requests.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FitnessPal.API.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class MealsController : BaseController
    {
        private readonly IMediator _mediator;

        public MealsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/Meals
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MealReadDto>>> GetMeals([FromQuery] DateTime date)
        {
            var meals = await _mediator.Send(new GetMealListRequest { Date = date, UserId = CurrentUserId });
            return Ok(meals);
        }

        // GET: api/Meals/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MealReadDto>> GetMeal(int id)
        {
            var meal = await _mediator.Send(new GetMealRequest { Id = id, UserId = CurrentUserId });
            return Ok(meal);
        }

        // PUT: api/Meals/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMeal(int id, [FromBody] MealUpdateDto meal)
        {
            await _mediator.Send(new UpdateMealCommand { Id = id, MealUpdateDto = meal, UserId = CurrentUserId });
            return NoContent();
        }

        // POST: api/Meals
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult> PostMeal([FromBody] MealCreateDto meal)
        {
            var response = await _mediator.Send(new CreateMealCommand { MealCreateDto = meal, UserId = CurrentUserId });
            return Ok(response);
        }

        // DELETE: api/Meals/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMeal(int id)
        {
            await _mediator.Send(new DeleteMealCommand { Id = id, UserId = CurrentUserId });
            return NoContent();
        }
    }
}

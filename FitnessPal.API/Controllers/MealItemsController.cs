using FitnessPal.Application.DTOs.MealItemDTOs;
using FitnessPal.Application.Features.MealItems.Requests.Commands;
using FitnessPal.Application.Features.MealItems.Requests.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FitnessPal.API.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class MealItemsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MealItemsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/MealItems/5
        [HttpGet("{mealId}")]
        public async Task<ActionResult<IEnumerable<MealItemReadDto>>> GetMealItems(int mealId)
        {
            var mealItems = await _mediator.Send(new GetMealItemListRequest() { MealId = mealId });
            return Ok(mealItems);
        }

        // GET: api/MealItems/5/3
        [HttpGet("{mealId}/{ingredientId}")]
        public async Task<ActionResult<MealItemReadDto>> GetMealItem(int mealId, int ingredientId)
        {
            var mealItem = await _mediator.Send(new GetMealItemRequest { MealId = mealId, IngredientId = ingredientId });
            return Ok(mealItem);
        }

        // PUT: api/MealItems/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{mealId}/{ingredientId}")]
        public async Task<IActionResult> PutMealItem(int mealId,int ingredientId, [FromBody] MealItemUpdateDto mealItem)
        {
            await _mediator.Send(new UpdateMealItemCommand { MealId = mealId, IngredientId = ingredientId, MealItemUpdateDto = mealItem });
            return NoContent();
        }

        // POST: api/MealItems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult> PostMealItem([FromBody] MealItemCreateDto mealItem)
        {
            var response = await _mediator.Send(new CreateMealItemCommand { MealItemCreateDto = mealItem });
            return Ok(response);
        }

        // DELETE: api/MealItems/5/3
        [HttpDelete("{mealId}/{ingredientId}")]
        public async Task<IActionResult> DeleteMealItems(int mealId,int ingredientId)
        {
            await _mediator.Send(new DeleteMealItemCommand { MealId = mealId, IngredientId = ingredientId });
            return NoContent();
        }
    }
}

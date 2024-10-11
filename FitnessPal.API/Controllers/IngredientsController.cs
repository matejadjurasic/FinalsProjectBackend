using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FitnessPal.Domain.Models;
using MediatR;
using FitnessPal.Application.DTOs.IngredientDTOs;
using FitnessPal.Application.Features.Ingredients.Requests.Queries;
using FitnessPal.Application.Features.Ingredients.Requests.Commands;
using Microsoft.AspNetCore.Authorization;

namespace FitnessPal.API.Controllers
{
    [Authorize(Policy = "Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class IngredientsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public IngredientsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/Ingredients
        [HttpGet]
        public async Task<ActionResult<IEnumerable<IngredientReadDto>>> GetIngredients()
        {
            var ingredients = await _mediator.Send(new GetIngredientListRequest());
            return Ok(ingredients);
        }

        // GET: api/Ingredients/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IngredientReadDto>> GetIngredient(int id)
        {
            var ingredient = await _mediator.Send(new GetIngredientRequest { Id = id });
            return Ok(ingredient);
        }

        // PUT: api/Ingredients/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutIngredient(int id, [FromBody] IngredientUpdateDto ingredient)
        {
            await _mediator.Send(new UpdateIngredientCommand { Id = id, IngredientUpdateDto = ingredient });
            return NoContent();
        }

        // POST: api/Ingredients
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult> PostIngredient([FromBody] IngredientCreateDto ingredient)
        {
            var response = await _mediator.Send(new CreateIngredientCommand { IngredientCreateDto = ingredient });
            return Ok(response);
        }

        // DELETE: api/Ingredients/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteIngredient(int id)
        {
            await _mediator.Send(new DeleteIngredientCommand { Id = id });
            return NoContent();
        }
    }
}

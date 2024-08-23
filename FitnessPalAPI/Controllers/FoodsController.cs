using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FitnessPalAPI.Data;
using FitnessPalAPI.Models.DatabaseModels;
using FitnessPalAPI.Models.DataTransferModels.FoodTransferModels;
using FitnessPalAPI.Services.FoodServices;

namespace FitnessPalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodsController : ControllerBase
    {
        private readonly IFoodService _foodService;

        public FoodsController(IFoodService foodService)
        {
            _foodService = foodService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<FoodReadDto>>> GetFoods()
        {
            var foods = await _foodService.GetAllFoodsAsync();
            return Ok(foods);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<FoodReadDto>> GetFood(int id)
        {
            var food = await _foodService.GetFoodByIdAsync(id);
            return Ok(food);
        }

        [HttpPost]
        public async Task<ActionResult<FoodReadDto>> PostFood(FoodCreateDto foodDto)
        {
            var createdFood = await _foodService.CreateFoodAsync(foodDto);
            return CreatedAtAction(nameof(GetFood), new { id = createdFood.Id }, createdFood);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutFood(int id, FoodUpdateDto foodDto)
        {
            var food = await _foodService.UpdateFoodAsync(id, foodDto);
            return Ok(food);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFood(int id)
        {
            await _foodService.DeleteFoodAsync(id);
            return NoContent();
        }
    }
}

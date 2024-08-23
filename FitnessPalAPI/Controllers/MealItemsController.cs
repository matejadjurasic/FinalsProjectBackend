using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FitnessPalAPI.Data;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using FitnessPalAPI.Models.DatabaseModels;
using FitnessPalAPI.Models.DataTransferModels.MealItemTransferModels;
using FitnessPalAPI.Services.MealItemServices;

namespace FitnessPalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class MealItemsController : ControllerBase
    {
        private readonly IMealItemService _mealItemService;

        public MealItemsController(IMealItemService mealItemService)
        {
            _mealItemService = mealItemService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MealItemReadDto>>> GetMealItems()
        {
            var mealItems = await _mealItemService.GetAllMealItemsAsync();
            return Ok(mealItems);
        }

        [HttpGet("{mealId}/{foodId}")]
        public async Task<ActionResult<MealItemReadDto>> GetMealItem(int mealId, int foodId)
        {
            var mealItem = await _mealItemService.GetMealItemByIdAsync(mealId, foodId);
            return Ok(mealItem);
        }

        [HttpPost]
        public async Task<IActionResult> PostMealItem(MealItemCreateDto mealItemDto)
        {
            await _mealItemService.CreateMealItemAsync(mealItemDto);
            return CreatedAtAction(nameof(GetMealItem), new { mealId = mealItemDto.MealId, foodId = mealItemDto.FoodId }, mealItemDto);
        }

        [HttpPut("{mealId}/{foodId}")]
        public async Task<IActionResult> PutMealItem(int mealId, int foodId, MealItemUpdateDto mealItemDto)
        {
            var mealItem = await _mealItemService.UpdateMealItemAsync(mealId, foodId, mealItemDto);
            return Ok(mealItem);
        }

        [HttpDelete("{mealId}/{foodId}")]
        public async Task<IActionResult> DeleteMealItem(int mealId, int foodId)
        {
            await _mealItemService.DeleteMealItemAsync(mealId, foodId);
            return NoContent();
        }
    }
}

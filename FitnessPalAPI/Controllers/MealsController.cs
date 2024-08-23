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
using FitnessPalAPI.Models.DataTransferModels.MealTransferModels;
using FitnessPalAPI.Services.MealServices;

namespace FitnessPalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class MealsController : BaseController
    {
        private readonly IMealService _mealService;

        public MealsController(IMealService mealService)
        {
            _mealService = mealService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MealReadDto>>> GetMeals()
        {
            var meals = await _mealService.GetAllMealsAsync(CurrentUserId);
            return Ok(meals);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MealReadDto>> GetMeal(int id)
        {
            var meal = await _mealService.GetMealByIdAsync(CurrentUserId, id);
            return Ok(meal);
        }

        [HttpPost]
        public async Task<ActionResult<MealReadDto>> PostMeal(MealCreateDto mealDto)
        {
            var newMeal = await _mealService.CreateMealAsync(CurrentUserId, mealDto);
            return CreatedAtAction(nameof(GetMeal), new { id = newMeal.Id }, newMeal);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutMeal(int id, MealUpdateDto mealDto)
        {
            MealReadDto meal = await _mealService.UpdateMealAsync(CurrentUserId, id, mealDto);
            return Ok(meal);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMeal(int id)
        {
            await _mealService.DeleteMealAsync(CurrentUserId, id);
            return Ok("Meal deleted successfully");
        }
    }
}

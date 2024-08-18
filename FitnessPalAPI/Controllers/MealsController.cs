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
    public class MealsController : ControllerBase
    {
        private readonly IMealService _mealService;

        public MealsController(IMealService mealService)
        {
            _mealService = mealService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MealReadDto>>> GetMeals()
        {
            int userId = GetUserIdFromToken();
            var meals = await _mealService.GetAllMealsAsync(userId);
            return Ok(meals);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MealReadDto>> GetMeal(int id)
        {
            int userId = GetUserIdFromToken();
            var meal = await _mealService.GetMealByIdAsync(userId, id);
            if (meal == null)
            {
                return NotFound();
            }
            return Ok(meal);
        }

        [HttpPost]
        public async Task<ActionResult<MealReadDto>> PostMeal(MealCreateDto mealDto)
        {
            int userId = GetUserIdFromToken();
            if (userId != mealDto.UserId)
            {
                return Unauthorized("Unauthorized to create meals for other users.");
            }
            var newMeal = await _mealService.CreateMealAsync(userId, mealDto);
            return CreatedAtAction(nameof(GetMeal), new { id = newMeal.Id }, newMeal);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutMeal(int id, MealUpdateDto mealDto)
        {
            int userId = GetUserIdFromToken();
            try
            {
                MealReadDto meal = await _mealService.UpdateMealAsync(userId, id, mealDto);
                return Ok(meal);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMeal(int id)
        {
            int userId = GetUserIdFromToken();
            bool success = await _mealService.DeleteMealAsync(userId, id);
            if (!success)
            {
                return NotFound();
            }
            return Ok("Meal deleted successfully");
        }

        private int GetUserIdFromToken()
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
            if (userIdClaim == null)
            {
                throw new Exception("User ID not found in token.");
            }
            return int.Parse(userIdClaim.Value);
        }
    }
}

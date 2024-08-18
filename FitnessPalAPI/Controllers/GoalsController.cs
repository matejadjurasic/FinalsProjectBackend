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
using FitnessPalAPI.Models.DataTransferModels.GoalTransferModels;
using FitnessPalAPI.Services.GoalServices;

namespace FitnessPalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class GoalsController : ControllerBase
    {
        private readonly IGoalService _goalService;

        public GoalsController(IGoalService goalService)
        {
            _goalService = goalService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GoalReadDto>>> GetGoals()
        {
            var userId = GetUserIdFromToken();
            var goals = await _goalService.GetGoalsByUserIdAsync(userId);
            return Ok(goals);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GoalReadDto>> GetGoal(int id)
        {
            var userId = GetUserIdFromToken();
            var goal = await _goalService.GetGoalByIdAsync(userId, id);
            if (goal == null)
            {
                return NotFound();
            }
            return Ok(goal);
        }

        [HttpPost]
        public async Task<ActionResult<GoalReadDto>> PostGoal(GoalCreateDto createDto)
        {
            var userId = GetUserIdFromToken();
            try
            {
                var createdGoal = await _goalService.CreateGoalAsync(userId, createDto);
                return CreatedAtAction(nameof(GetGoal), new { id = createdGoal.Id }, createdGoal);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutGoal(int id, GoalUpdateDto updateDto)
        {
            var userId = GetUserIdFromToken();
            try
            {
                GoalReadDto goal = await _goalService.UpdateGoalAsync(userId, id, updateDto);
                return Ok(goal);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGoal(int id)
        {
            var userId = GetUserIdFromToken();
            bool success = await _goalService.DeleteGoalAsync(userId, id);
            if (!success)
            {
                return NotFound();
            }
            return Ok("Goal Deleted succesfully");
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

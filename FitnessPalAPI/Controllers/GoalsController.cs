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
    public class GoalsController : BaseController
    {
        private readonly IGoalService _goalService;

        public GoalsController(IGoalService goalService)
        {
            _goalService = goalService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GoalReadDto>>> GetGoals()
        {
            var goals = await _goalService.GetGoalsByUserIdAsync(CurrentUserId);
            return Ok(goals);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GoalReadDto>> GetGoal(int id)
        {
            var goal = await _goalService.GetGoalByIdAsync(CurrentUserId, id);
            return Ok(goal);
        }

        [HttpPost]
        public async Task<ActionResult<GoalReadDto>> PostGoal(GoalCreateDto createDto)
        {
            var createdGoal = await _goalService.CreateGoalAsync(CurrentUserId, createDto);
            return CreatedAtAction(nameof(GetGoal), new { id = createdGoal.Id }, createdGoal);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutGoal(int id, GoalUpdateDto updateDto)
        {

            var goal = await _goalService.UpdateGoalAsync(CurrentUserId, id, updateDto);
            return Ok(goal);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGoal(int id)
        {
            await _goalService.DeleteGoalAsync(CurrentUserId, id);
            return NoContent();
        }
    }    
}

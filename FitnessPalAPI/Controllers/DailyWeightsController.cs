using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FitnessPalAPI.Data;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using FitnessPalAPI.Models.DatabaseModels;
using FitnessPalAPI.Models.DataTransferModels.DailyWeightTransferModels;
using FitnessPalAPI.Services.DailyWeightServices;

namespace FitnessPalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class DailyWeightsController : ControllerBase
    {
        private readonly IDailyWeightService _dailyWeightService;

        public DailyWeightsController(IDailyWeightService dailyWeightService)
        {
            _dailyWeightService = dailyWeightService;
        }

        private int GetUserId()
        {
            // Extract the user's ID from the claim
            var userIdString = User.FindFirstValue(ClaimTypes.NameIdentifier);
            return int.TryParse(userIdString, out var userId) ? userId : throw new Exception("User ID not found");
        }

        // GET: api/DailyWeights
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DailyWeightReadDto>>> GetDailyWeights()
        {
            int userId = GetUserId();
            var weights = await _dailyWeightService.GetAllWeightsAsync(userId);
            return Ok(weights);
        }

        // GET: api/DailyWeights/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DailyWeightReadDto>> GetDailyWeight(int id)
        {
            int userId = GetUserId();
            var dailyWeight = await _dailyWeightService.GetWeightByIdAsync(userId, id);
            if (dailyWeight == null)
            {
                return NotFound();
            }
            return Ok(dailyWeight);
        }

        // POST: api/DailyWeights
        [HttpPost]
        public async Task<ActionResult<DailyWeightReadDto>> PostDailyWeight(DailyWeightCreateDto dailyWeightDto)
        {
            int userId = GetUserId();
            try
            {
                var createdDailyWeight = await _dailyWeightService.CreateWeightAsync(userId, dailyWeightDto);
                return CreatedAtAction(nameof(GetDailyWeight), new { id = createdDailyWeight.Id }, createdDailyWeight);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT: api/DailyWeights/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDailyWeight(int id, DailyWeightUpdateDto dailyWeightDto)
        {
            int userId = GetUserId();
            try
            {
                DailyWeightReadDto dailyWeight = await _dailyWeightService.UpdateWeightAsync(userId, id, dailyWeightDto);
                return Ok(dailyWeight);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

        // DELETE: api/DailyWeights/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDailyWeight(int id)
        {
            int userId = GetUserId();
            try
            {
                await _dailyWeightService.DeleteWeightAsync(userId, id);
                return Ok("DailyWeight deleted successfully!");
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }
    }
}

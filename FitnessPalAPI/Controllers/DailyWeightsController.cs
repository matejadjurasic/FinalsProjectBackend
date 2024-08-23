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
using FitnessPalAPI.Validators;

namespace FitnessPalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class DailyWeightsController : BaseController
    {
        private readonly IDailyWeightService _dailyWeightService;

        public DailyWeightsController(IDailyWeightService dailyWeightService)
        {
            _dailyWeightService = dailyWeightService;
        }

        // GET: api/DailyWeights
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DailyWeightReadDto>>> GetDailyWeights()
        {
            var weights = await _dailyWeightService.GetAllWeightsAsync(CurrentUserId);
            return Ok(weights);
        }

        // GET: api/DailyWeights/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DailyWeightReadDto>> GetDailyWeight(int id)
        {
            var dailyWeight = await _dailyWeightService.GetWeightByIdAsync(CurrentUserId, id);
            return Ok(dailyWeight);
        }

        // POST: api/DailyWeights
        [HttpPost]
        public async Task<ActionResult<DailyWeightReadDto>> PostDailyWeight([FromBody] DailyWeightCreateDto dailyWeightDto)
        {
            var createdDailyWeight = await _dailyWeightService.CreateWeightAsync(CurrentUserId, dailyWeightDto);
            return CreatedAtAction(nameof(GetDailyWeight), new { id = createdDailyWeight.Id }, createdDailyWeight);
        }

        // PUT: api/DailyWeights/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDailyWeight(int id,[FromBody] DailyWeightUpdateDto dailyWeightDto)
        {
            var dailyWeight = await _dailyWeightService.UpdateWeightAsync(CurrentUserId, id, dailyWeightDto);
            return Ok(dailyWeight);   
        }

        // DELETE: api/DailyWeights/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDailyWeight(int id)
        {

            await _dailyWeightService.DeleteWeightAsync(CurrentUserId, id);
            return NoContent();
        }
    }
}

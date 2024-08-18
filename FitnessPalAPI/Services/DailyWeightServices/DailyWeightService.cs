using AutoMapper;
using FitnessPalAPI.Models.DataTransferModels.DailyWeightTransferModels;
using FitnessPalAPI.Models.DatabaseModels;

namespace FitnessPalAPI.Services.DailyWeightServices
{
    public class DailyWeightService : IDailyWeightService
    {
        private readonly IDailyWeightRepository _repository;
        private readonly IMapper _mapper;

        public DailyWeightService(IDailyWeightRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<DailyWeightReadDto>> GetAllWeightsAsync(int userId)
        {
            var weights = await _repository.GetAllWeightsAsync(userId);
            return _mapper.Map<IEnumerable<DailyWeightReadDto>>(weights);
        }

        public async Task<DailyWeightReadDto> GetWeightByIdAsync(int userId, int weightId)
        {
            var weight = await _repository.GetWeightByIdAsync(userId, weightId);
            if (weight != null)
            {
                return _mapper.Map<DailyWeightReadDto>(weight);
            }
            return null;
        }

        public async Task<DailyWeightReadDto> CreateWeightAsync(int userId, DailyWeightCreateDto createDto)
        {
            if (await _repository.WeightExistsAsync(userId, createDto.DateTime))
            {
                throw new InvalidOperationException("Only one weight entry per day is allowed.");
            }

            var dailyWeight = _mapper.Map<DailyWeight>(createDto);
            dailyWeight.UserId = userId;  // Set user ID to ensure the weight is associated with the correct user.

            await _repository.AddWeightAsync(dailyWeight);
            return _mapper.Map<DailyWeightReadDto>(dailyWeight);  // Return the created DailyWeight DTO.
        }

        public async Task<DailyWeightReadDto> UpdateWeightAsync(int userId, int weightId, DailyWeightUpdateDto updateDto)
        {
            var weight = await _repository.GetWeightByIdAsync(userId, weightId);
            if (weight == null)
            {
                throw new KeyNotFoundException("Weight not found.");
            }

            // Update the weight with new details from updateDto
            _mapper.Map(updateDto, weight);
            await _repository.UpdateWeightAsync(weight);
            return _mapper.Map<DailyWeightReadDto>(weight);
        }

        public async Task<bool> DeleteWeightAsync(int userId, int weightId)
        {
            var success = await _repository.DeleteWeightAsync(userId, weightId);
            if (!success)
            {
                throw new KeyNotFoundException("Weight not found or already removed.");
            }
            return true;
        }
    }
}

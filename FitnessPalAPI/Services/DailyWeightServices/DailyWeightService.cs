using AutoMapper;
using FitnessPalAPI.Models.DataTransferModels.DailyWeightTransferModels;
using FitnessPalAPI.Models.DatabaseModels;
using FitnessPalAPI.Exceptions;

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
            var weight = await _repository.GetWeightByIdAsync(userId, weightId) ?? throw new NotFoundException("Weight not found.");
            return _mapper.Map<DailyWeightReadDto>(weight);
        }

        public async Task<DailyWeightReadDto> CreateWeightAsync(int userId, DailyWeightCreateDto createDto)
        {
            if (await _repository.WeightExistsAsync(userId, createDto.DateTime))
            {
                throw new InvalidOperationException("Only one weight entry per day is allowed.");
            }

            var dailyWeight = _mapper.Map<DailyWeight>(createDto);
            dailyWeight.UserId = userId;  

            await _repository.AddWeightAsync(dailyWeight);
            return _mapper.Map<DailyWeightReadDto>(dailyWeight);
        }

        public async Task<DailyWeightReadDto> UpdateWeightAsync(int userId, int weightId, DailyWeightUpdateDto updateDto)
        {
            var weight = await _repository.GetWeightByIdAsync(userId, weightId) ?? throw new NotFoundException("Weight not found.");

            _mapper.Map(updateDto, weight);
            await _repository.UpdateWeightAsync(weight);
            return _mapper.Map<DailyWeightReadDto>(weight);
        }

        public async Task DeleteWeightAsync(int userId, int weightId)
        {
            var dailyWeight = await _repository.GetWeightByIdAsync(userId, weightId) ?? throw new NotFoundException("Weight not found or already removed.");
            await _repository.DeleteWeightAsync(dailyWeight);
        }
    }
}

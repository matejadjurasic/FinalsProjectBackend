using AutoMapper;
using FitnessPalAPI.Exceptions;
using FitnessPalAPI.Models.DatabaseModels;
using FitnessPalAPI.Models.DataTransferModels.FoodTransferModels;

namespace FitnessPalAPI.Services.FoodServices
{
    public class FoodService : IFoodService
    {
        private readonly IFoodRepository _repository;
        private readonly IMapper _mapper;

        public FoodService(IFoodRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<FoodReadDto>> GetAllFoodsAsync()
        {
            var foods = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<FoodReadDto>>(foods);
        }

        public async Task<FoodReadDto> GetFoodByIdAsync(int foodId)
        {
            var food = await _repository.GetByIdAsync(foodId) ?? throw new NotFoundException("Food not found");
            return _mapper.Map<FoodReadDto>(food);
        }

        public async Task<FoodReadDto> CreateFoodAsync(FoodCreateDto foodDto)
        {
            var food = _mapper.Map<Food>(foodDto);
            await _repository.AddAsync(food);
            return _mapper.Map<FoodReadDto>(food);
        }

        public async Task<FoodReadDto> UpdateFoodAsync(int foodId, FoodUpdateDto foodDto)
        {
            var food = await _repository.GetByIdAsync(foodId) ?? throw new NotFoundException("Food not found");
            _mapper.Map(foodDto, food);
            await _repository.UpdateAsync(food);
            return _mapper.Map<FoodReadDto>(food);
        }

        public async Task DeleteFoodAsync(int foodId)
        {
            var food = await _repository.GetByIdAsync(foodId) ?? throw new InvalidOperationException("Food not found.");
            await _repository.DeleteAsync(food);
        }
    }
}

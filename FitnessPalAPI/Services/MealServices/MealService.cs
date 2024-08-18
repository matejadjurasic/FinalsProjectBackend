using AutoMapper;
using FitnessPalAPI.Models.DatabaseModels;
using FitnessPalAPI.Models.DataTransferModels.MealTransferModels;

namespace FitnessPalAPI.Services.MealServices
{
    public class MealService : IMealService
    {
        private readonly IMealRepository _repository;
        private readonly IMapper _mapper;

        public MealService(IMealRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<MealReadDto>> GetAllMealsAsync(int userId)
        {
            var meals = await _repository.GetAllByUserIdAsync(userId);
            return _mapper.Map<IEnumerable<MealReadDto>>(meals);
        }

        public async Task<MealReadDto> GetMealByIdAsync(int userId, int mealId)
        {
            var meal = await _repository.GetByIdAndUserIdAsync(mealId, userId);
            if (meal == null) return null;
            return _mapper.Map<MealReadDto>(meal);
        }

        public async Task<MealReadDto> CreateMealAsync(int userId, MealCreateDto mealDto)
        {
            if (userId != mealDto.UserId)
            {
                throw new InvalidOperationException("Unauthorized attempt to create a meal for another user.");
            }

            var meal = _mapper.Map<Meal>(mealDto);
            meal.UserId = userId; // Ensuring the UserId is set correctly
            await _repository.AddAsync(meal);
            return _mapper.Map<MealReadDto>(meal);
        }

        public async Task<MealReadDto> UpdateMealAsync(int userId, int mealId, MealUpdateDto mealDto)
        {
            var meal = await _repository.GetByIdAndUserIdAsync(mealId, userId);
            if (meal == null)
                throw new InvalidOperationException("Meal not found.");

            _mapper.Map(mealDto, meal);
            await _repository.UpdateAsync(meal);
            return _mapper.Map<MealReadDto>(meal);
        }

        public async Task<bool> DeleteMealAsync(int userId, int mealId)
        {
            var meal = await _repository.GetByIdAndUserIdAsync(mealId, userId);
            if (meal == null) return false;

            await _repository.DeleteAsync(meal);
            return true;
        }
    }
}

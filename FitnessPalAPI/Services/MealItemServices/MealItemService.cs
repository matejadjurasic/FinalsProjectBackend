using AutoMapper;
using FitnessPalAPI.Models.DatabaseModels;
using FitnessPalAPI.Models.DataTransferModels.MealItemTransferModels;

namespace FitnessPalAPI.Services.MealItemServices
{
    public class MealItemService : IMealItemService
    {
        private readonly IMealItemRepository _repository;
        private readonly IMapper _mapper;

        public MealItemService(IMealItemRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<MealItemReadDto>> GetAllMealItemsAsync()
        {
            var mealItems = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<MealItemReadDto>>(mealItems);
        }

        public async Task<MealItemReadDto> GetMealItemByIdAsync(int mealId, int foodId)
        {
            var mealItem = await _repository.GetByIdAsync(mealId,foodId);
            return _mapper.Map<MealItemReadDto>(mealItem);
        }

        public async Task<MealItemReadDto> CreateMealItemAsync(MealItemCreateDto mealItemDto)
        {
            var mealItem = _mapper.Map<MealItem>(mealItemDto);
            await _repository.AddAsync(mealItem);
            return _mapper.Map<MealItemReadDto>(mealItem);
        }

        public async Task<MealItemReadDto> UpdateMealItemAsync(int mealId,int foodId, MealItemUpdateDto mealItemDto)
        {
            var mealItem = await _repository.GetByIdAsync(mealId,foodId);
            if (mealItem == null)
                throw new InvalidOperationException("MealItem not found.");

            // Manually update the 'Amount' field since the DTO only contains this field.
            mealItem.Amount = mealItemDto.Amount;

            await _repository.UpdateAsync(mealItem);
            return _mapper.Map<MealItemReadDto>(mealItem);
        }

        public async Task DeleteMealItemAsync(int mealId,int foodId)
        {
            var mealItem = await _repository.GetByIdAsync(mealId,foodId);
            if (mealItem == null)
                throw new InvalidOperationException("MealItem not found.");

            await _repository.DeleteAsync(mealItem);
        }
    }
}

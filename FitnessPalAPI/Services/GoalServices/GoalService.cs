using AutoMapper;
using FitnessPalAPI.Exceptions;
using FitnessPalAPI.Models.DatabaseModels;
using FitnessPalAPI.Models.DataTransferModels.GoalTransferModels;

namespace FitnessPalAPI.Services.GoalServices
{
    public class GoalService : IGoalService
    {
        private readonly IGoalRepository _repository;
        private readonly IMapper _mapper;

        public GoalService(IGoalRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<GoalReadDto>> GetGoalsByUserIdAsync(int userId)
        {
            var goals = await _repository.GetAllAsync(userId);
            return _mapper.Map<IEnumerable<GoalReadDto>>(goals);
        }

        public async Task<GoalReadDto> GetGoalByIdAsync(int userId, int goalId)
        {
            var goal = await _repository.GetByIdAsync(userId, goalId) ?? throw new NotFoundException("Goal not found");
            return _mapper.Map<GoalReadDto>(goal);
        }

        public async Task<GoalReadDto> CreateGoalAsync(int userId, GoalCreateDto createDto)
        {
            if (await _repository.ExistsAsync(userId))
            {
                throw new InvalidOperationException("User can only have one goal.");
            }

            var goal = _mapper.Map<Goal>(createDto);
            goal.UserId = userId;
            await _repository.AddAsync(goal);
            return _mapper.Map<GoalReadDto>(goal);
        }

        public async Task<GoalReadDto> UpdateGoalAsync(int userId, int goalId, GoalUpdateDto updateDto)
        {
            var goal = await _repository.GetByIdAsync(userId, goalId) ?? throw new NotFoundException("Goal not found.");
            _mapper.Map(updateDto, goal);
            await _repository.UpdateAsync(goal);
            return _mapper.Map<GoalReadDto>(goal);
        }

        public async Task DeleteGoalAsync(int userId, int goalId)
        {
            var goal = await _repository.GetByIdAsync(userId, goalId) ?? throw new NotFoundException("Goal not found");
            await _repository.DeleteAsync(goal);
        }
    }
}

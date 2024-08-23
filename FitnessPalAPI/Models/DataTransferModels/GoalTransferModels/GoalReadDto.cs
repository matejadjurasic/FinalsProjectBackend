using FitnessPalAPI.Models.Enums;

namespace FitnessPalAPI.Models.DataTransferModels.GoalTransferModels
{
    public class GoalReadDto : GoalBaseDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
    }
}

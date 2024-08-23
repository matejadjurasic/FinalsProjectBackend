using FitnessPalAPI.Models.Enums;

namespace FitnessPalAPI.Models.DataTransferModels.GoalTransferModels
{
    public class GoalCreateDto : GoalBaseDto
    {
        public int UserId { get; set; }
    }
}

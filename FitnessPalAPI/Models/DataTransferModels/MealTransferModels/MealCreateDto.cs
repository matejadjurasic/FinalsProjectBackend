using FitnessPalAPI.Models.Enums;

namespace FitnessPalAPI.Models.DataTransferModels.MealTransferModels
{
    public class MealCreateDto : MealBaseDto
    {
        public int UserId { get; set; }
    }
}

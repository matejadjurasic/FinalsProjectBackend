using FitnessPalAPI.Models.Enums;

namespace FitnessPalAPI.Models.DataTransferModels.MealTransferModels
{
    public class MealReadDto : MealBaseDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
    }
}

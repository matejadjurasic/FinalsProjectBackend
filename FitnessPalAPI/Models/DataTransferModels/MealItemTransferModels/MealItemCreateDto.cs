namespace FitnessPalAPI.Models.DataTransferModels.MealItemTransferModels
{
    public class MealItemCreateDto : MealItemBaseDto
    {
        public int MealId { get; set; }
        public int FoodId { get; set; }
    }
}

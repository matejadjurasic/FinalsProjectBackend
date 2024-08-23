namespace FitnessPalAPI.Models.DataTransferModels.MealItemTransferModels
{
    public class MealItemReadDto : MealItemBaseDto
    {
        public int MealId { get; set; }
        public int FoodId { get; set; }
    }
}

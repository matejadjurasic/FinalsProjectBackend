namespace FitnessPalAPI.Models.DataTransferModels.MealItemTransferModels
{
    public class MealItemCreateDto
    {
        public int MealId { get; set; }
        public int FoodId { get; set; }
        public double Amount { get; set; }
    }
}

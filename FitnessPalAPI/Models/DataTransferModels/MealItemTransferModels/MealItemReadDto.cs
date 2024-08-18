namespace FitnessPalAPI.Models.DataTransferModels.MealItemTransferModels
{
    public class MealItemReadDto
    {
        public int MealId { get; set; }
        public int FoodId { get; set; }
        public double Amount { get; set; }
    }
}

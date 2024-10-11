namespace FitnessPal.Application.DTOs.MealItemDTOs
{
    public class MealItemCreateDto : MealItemBaseDto
    {
        public int MealId { get; set; }
        public int IngredientId { get; set; }
    }
}

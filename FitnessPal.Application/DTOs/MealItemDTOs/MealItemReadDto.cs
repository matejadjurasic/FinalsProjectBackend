namespace FitnessPal.Application.DTOs.MealItemDTOs
{
    public class MealItemReadDto : MealItemBaseDto
    {
        public int MealId { get; set; }
        public int IngredientId { get; set; }
    }
}

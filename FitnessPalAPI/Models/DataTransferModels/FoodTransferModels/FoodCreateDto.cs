namespace FitnessPalAPI.Models.DataTransferModels.FoodTransferModels
{
    public class FoodCreateDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Calories { get; set; }
        public double Protein { get; set; }
        public double Carbs { get; set; }
        public double Fat { get; set; }
    }
}

namespace FitnessPalAPI.Models.DataTransferModels.FoodTransferModels
{
    public class FoodBaseDto
    {
        public string Name { get; set; } = string.Empty;    
        public string Description { get; set; } = string.Empty;
        public int Calories { get; set; }
        public double Protein { get; set; }
        public double Carbs { get; set; }
        public double Fat { get; set; }
    }
}

namespace FitnessPalAPI.Models.DataTransferModels.DailyWeightTransferModels
{
    public class DailyWeightCreateDto
    {
        public DateTime DateTime { get; set; }
        public double Weight { get; set; }
        public int UserId { get; set; }
    }
}

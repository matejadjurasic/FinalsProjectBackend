namespace FitnessPalAPI.Models.DataTransferModels.DailyWeightTransferModels
{
    public class DailyWeightReadDto
    {
        public int Id { get; set; }
        public DateTime DateTime { get; set; }
        public double Weight { get; set; }
        public int UserId { get; set; }
    }
}

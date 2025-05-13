namespace EgyptMart.Services.ReportingAPI.DTO
{
    public class SDA_ProductReviewDto
    {
        public int AverageUser { get; set; }
        public long ProductID { get; set; }
        public string? ProductTitle { get; set; }
        public int AverageRating { get; set; }
    }
}

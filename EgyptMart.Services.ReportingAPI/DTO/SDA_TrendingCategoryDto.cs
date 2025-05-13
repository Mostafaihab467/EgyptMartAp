namespace EgyptMart.Services.ReportingAPI.DTO
{
    public class SDA_TrendingCategoryDto
    {
        public long? CategoryID { get; set; }
        public string? CategoryTitle { get; set; } = string.Empty;
        public long? CategoryViewCount { get; set; }
    }
}

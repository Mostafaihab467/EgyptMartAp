namespace EgyptMart.Services.ReportingAPI.DTO
{
    public class SDA_TrendingProductInsertDto
    {

        public long OwnerID { get; set; }
        public long ProductID { get; set; }
        public long CategoryID { get; set; }
        public string ProductTitle { get; set; } = string.Empty;
        public long ViewCount { get; set; }
    }
}

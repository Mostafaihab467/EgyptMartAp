namespace EgyptMart.Services.ReportingAPI.Models
{
    public class ADA_TopRateProductModel
    {
        public long ProductID { get; set; } // bigint
        public string ProductTitle { get; set; } // nvarchar(250)
        public int AvgRating { get; set; } // nvarchar(250)
        public int RatingCount { get; set; } // int
    }
}

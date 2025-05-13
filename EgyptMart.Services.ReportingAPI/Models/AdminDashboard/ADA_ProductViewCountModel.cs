namespace EgyptMart.Services.ReportingAPI.Models
{
    public class ADA_ProductViewCountModel
    {
        public long ProductID { get; set; } // bigint
        public string? ProductTitle { get; set; }
        public int TotalViews { get; set; } // int
    }
}

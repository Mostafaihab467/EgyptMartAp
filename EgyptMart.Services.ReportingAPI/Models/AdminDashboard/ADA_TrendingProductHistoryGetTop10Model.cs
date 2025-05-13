namespace EgyptMart.Services.ReportingAPI.Models
{
    public class ADA_TrendingProductHistoryGetTop10Model
    {

        public long ProductID { get; set; }        // bigint in SQL corresponds to long in C#
        public long OwnerID { get; set; }          // bigint in SQL corresponds to long in C#
        public int TotalOverViews { get; set; }    // int in SQL corresponds to int in C#
        public DateTime LastUpdatedDate { get; set; } // datetime in SQL corresponds to DateTime in C#

    }
}

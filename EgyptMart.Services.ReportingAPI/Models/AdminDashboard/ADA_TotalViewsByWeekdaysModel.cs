namespace EgyptMart.Services.ReportingAPI.Models
{
    public class ADA_TotalViewsByWeekdaysModel
    {

        public string ViewDay { get; set; }    // nvarchar(30) in SQL corresponds to string in C#
        public int ViewsCount { get; set; }    // int in SQL corresponds to int in C#

    }
}

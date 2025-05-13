namespace EgyptMart.Services.ReportingAPI.Models
{
    public class ADA_TrendingCategoryModel
    {

        public long CategoryID { get; set; }        // bigint in SQL corresponds to long in C#
        public string CategoryTitle { get; set; }   // varchar(200) in SQL corresponds to string in C#
        public long? CategoryViewCount { get; set; } // bigint in SQL corresponds to long in C#


    }
}

namespace EgyptMart.Services.ReportingAPI.Models
{
    public class ADA_CategoryViewsByDaysModel
    {
        public int CategoryID { get; set; } // int
        public string CategoryTitle { get; set; } // varchar(200)
        public int TotalCategoryViews { get; set; } // int
    }
}

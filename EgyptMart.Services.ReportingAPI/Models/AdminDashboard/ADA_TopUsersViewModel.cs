namespace EgyptMart.Services.ReportingAPI.Models
{
    public class ADA_TopUsersViewModel
    {
        public long UserID { get; set; } // bigint
        public string DisplayName { get; set; } // nvarchar(150)
        public int ViewCount { get; set; } // int

    }
}

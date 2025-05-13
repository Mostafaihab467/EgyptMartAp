namespace EgyptMart.Services.ReportingAPI.Models
{
    public class ADA_UserSubscriptionWillFinishModel
    {
        public long UserID { get; set; }
        public string? DisplayName { get; set; }
        public DateTime EndDate { get; set; }
    }

    public class ADA_UserSubscriptionWillFinishModel_V2
    {
        public long UserID { get; set; }
        public string? DisplayName { get; set; }
        public long PlanID { get; set; }
        public string? PlanTitle { get; set; }
        public long SubscriptionID { get; set; }
        public DateTime EndDate { get; set; }
    }
}

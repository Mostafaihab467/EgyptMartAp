namespace EgyptMart.Services.ReportingAPI.Models
{
    public class ADA_UserSubscriptionCountByPlanModel
    {
        public long PlanId { get; set; }
        public int PlansCount { get; set; }
    }

    public class ADA_UserSubscriptionCountByPlanModel_V2
    {
        public long PlanId { get; set; }
        public string? PlanTitle { get; set; }
        public int PlansCount { get; set; }
    }
}

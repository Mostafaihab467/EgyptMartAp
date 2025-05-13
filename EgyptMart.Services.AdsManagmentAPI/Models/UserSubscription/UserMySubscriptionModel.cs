namespace EgyptMart.Services.AdsManagmentAPI.Models
{
    public class UserMySubscriptionModel
    {

        public long SubscribtionID { get; set; }
        public long UserID { get; set; }
        public long PlanID { get; set; }
        public string? PlanTitle { get; set; }
        public short LocationID { get; set; }
        public string? AdsLocationTitle { get; set; }
        public string? AdsImageUrl { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal Cost { get; set; }
        public bool IsActive { get; set; }
        public string? TargetURL { get; set; }

    }
}

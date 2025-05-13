namespace EgyptMart.Services.AdsManagmentAPI.Models
{
    public class SubscriptionsListModel
    {
        public long AdsPlanID { get; set; }
        public string PlanTitle { get; set; }
        public short LocationID { get; set; }
        public byte DurationDays { get; set; }
        public decimal CostBefore { get; set; }
        public decimal Cost { get; set; }
        public string PlanDescription { get; set; }
        public byte LangID { get; set; }
        public long BasePlanID { get; set; }
        public bool IsActive { get; set; }
        public string AdsLocationTitle { get; set; }
    }
}

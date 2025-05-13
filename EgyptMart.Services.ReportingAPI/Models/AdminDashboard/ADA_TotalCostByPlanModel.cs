namespace EgyptMart.Services.ReportingAPI.Models
{
    public class ADA_TotalCostByPlanModel
    {

        public long PlanID { get; set; }     // bigint in SQL corresponds to long in C#
        public decimal TotalCost { get; set; } // decimal(38,2) in SQL corresponds to decimal in C#


    }
}

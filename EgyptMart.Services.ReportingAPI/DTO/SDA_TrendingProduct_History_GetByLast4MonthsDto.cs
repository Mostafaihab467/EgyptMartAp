namespace EgyptMart.Services.ReportingAPI.DTO
{
    public class SDA_TrendingProduct_History_GetByLast4MonthsDto
    {

        public long ID { get; set; }
        public long ProductID { get; set; }
        public long OwnerID { get; set; }
        public int OverViews { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}

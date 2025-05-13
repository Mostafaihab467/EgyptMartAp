namespace EgyptMart.Services.ReportingAPI.DTO
{
    public class SDA_OutOfStockProductDto
    {
        public long ProductsID { get; set; }
        public string ProductTitle { get; set; }
        public string ShortDesc { get; set; }
        public byte OverallRating { get; set; }
        public int StockSimpleCounter { get; set; }
    }
}


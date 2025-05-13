#nullable disable
namespace EgyptMart.Services.ProductsAPI.Models
{
    public class ProductListModelView
    {
        public Int64 ProductsID { get; set; }
        public Int64 OwnerID { get; set; }
        //public long BaseProductID { get; set; }
        public string? CompanyTitle { get; set; }
        public byte LangID { get; set; }
        public string? ProductTitle { get; set; }
        public int? CategoryID { get; set; }
        public string? CategoryTitle { get; set; }
        public string? SEOKey { get; set; }
        public string? SKU { get; set; }
        public string? GSCode { get; set; }
        public string? ShortDesc { get; set; }
        public string? FullDesc { get; set; }
        public Int64? ViewsCount { get; set; }
        public byte? OverallRating { get; set; }
        public bool IsActive { get; set; }
        public string? MinimumOrder { get; set; }
        public decimal CostBefore { get; set; }
        public decimal CostAfter { get; set; }
        public bool StockStatus { get; set; }
        public int StockSimpleCounter { get; set; }
        public string? ImageURL { get; set; }


    }
}

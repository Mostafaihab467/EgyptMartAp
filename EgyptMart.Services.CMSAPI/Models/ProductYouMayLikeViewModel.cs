namespace EgyptMart.Services.CMSAPI.Models
{
    public class ProductYouMayLikeViewModel
    {
        public long ProductsID { get; set; }
        public long? OwnerID { get; set; }
        public string? CompanyTitle { get; set; }
        public long? BaseProductID { get; set; }
        public byte? LangID { get; set; }
        public string? ProductTitle { get; set; }
        public int? CategoryID { get; set; }
        public string? CategoryTitle { get; set; }
        public string? SEOKey { get; set; }
        public string? SKU { get; set; }
        public string? GSCode { get; set; }
        public string? ShortDesc { get; set; }
        public string? FullDesc { get; set; }
        public long? ViewsCount { get; set; }
        public byte? OverallRating { get; set; }
        public bool? IsActive { get; set; }
        public long? ImageID { get; set; }
        public string? ImageURL { get; set; }
        public bool? IsMain { get; set; }
        public string? MinimumOrder { get; set; }
        public decimal? CostBefore { get; set; }
        public decimal? CostAfter { get; set; }
        public bool? StockStatus { get; set; }
        public int? StockSimpleCounter { get; set; }
    }

}

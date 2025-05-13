namespace EgyptMart.Services.ProductsAPI.Models
{
    public class ProductListPaginatedModelView
    {
        public Int64 ProductsID { get; set; }
        public Int64 OwnerID { get; set; }
        public Int64 BaseProductID { get; set; }
        public string? CompanyTitle { get; set; }
        public byte LangID { get; set; }
        public string? ProductTitle { get; set; }
        public int CategoryID { get; set; }
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
        public int TotalCount { get; set; }

        public ProductListModelView GetList()
        {
            return new ProductListModelView
            {
                ProductsID = ProductsID,
                OwnerID = OwnerID,
                //BaseProductID = BaseProductID,
                CompanyTitle = CompanyTitle,
                LangID = LangID,
                ProductTitle = ProductTitle,
                CategoryID = CategoryID,
                CategoryTitle = CategoryTitle,
                SEOKey = SEOKey,
                SKU = SKU,
                GSCode = GSCode,
                ShortDesc = ShortDesc,
                FullDesc = FullDesc,
                ViewsCount = ViewsCount,
                OverallRating = OverallRating,
                IsActive = IsActive,
                MinimumOrder = MinimumOrder,
                CostBefore = CostBefore,
                CostAfter = CostAfter,
                StockStatus = StockStatus,
                StockSimpleCounter = StockSimpleCounter,
                ImageURL = ImageURL
                // No TotalCount field in ProductListModelView
            };
        }
    }
}

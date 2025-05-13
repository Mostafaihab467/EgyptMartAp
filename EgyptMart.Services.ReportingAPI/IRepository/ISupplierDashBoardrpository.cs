using EgyptMart.Services.ReportingAPI.DTO;

namespace EgyptMart.Services.ReportingAPI.IRepository
{
    public interface ISupplierDashBoardrpository
    {

        public Task<List<SDA_ViewCountByAgeDto>> ViewCountByAgeget(int SupplierID);
        public Task<int> TrendingProductInsertDto(SDA_TrendingProductInsertDto sDA_TrendingProductInsert);
        public Task<List<SDA_TrendingProduct_History_GetByLast4MonthsDto>> TrendingProduct_History_GetByLast4Months(long productId, long ownerId);
        public Task<List<SDA_TrendingProductDto>> GetTopTrendingProductsAsync(int days, long ownerId, int top = 5, byte LangID = 1);
        public Task<List<SDA_TrendingCategoryDto>> GetTrendingCategoriesByOwnerAsync(long ownerId, int days = 30, int top = 5, byte LangID = 1);
        public Task<List<SDA_TotalViewsByWeekdayDto>> GetTotalViewsByWeekdaysAsync(long supplierId, byte LangID);


        public Task<List<SDA_TotalViewsByRegisterDto>> GetTotalViewsByRegisterAsync(long OwnerID, int days, int top = 5);

        public Task<List<SDA_TotalProductViewByGenderDto>> GetTotalProductViewByGenderAsync(long ownerId);

        public Task<List<SDA_TopUserViewDto>> GetTopUsersViewAsync(long supplierId, int top = 5, int lastDays = 3);


        public Task<List<SDA_TopRatedProductDto>> GetTopRatedProductsAsync(long ownerId, int top = 5, byte langID = 1);
        public Task<int> UpdateProductViewCountAsync(long productId);


        public Task<List<SDA_ProductViewCountDto>> GetProductViewCountByDaysAsync(long productId, int days);

        public Task<List<SDA_ProductReviewDto>> GetTopReviewedProductsAsync(long ownerId, bool orderByDesc, byte langId);


        public Task<List<SDA_ProductViewCountLastXDaysDto>> GetProductViewCountByLastDaysAsync(long ownerId, int days);


        public Task<List<SDA_CategoryWithProductCountDto>> GetCategoryProductCountsAsync(long ownerId, byte LangId);


        public Task<List<SDA_AdsSubscriptionStatusDto>> GetAdsSubscriptionStatusAsync(long userId);
















    }
}

using EgyptMart.Services.ReportingAPI.Models;

namespace EgyptMart.Services.ReportingAPI.IRepository
{
    public interface IAdminDashboardRepository
    {

        Task<List<ADA_ViewCountByAgeModel>> ViewCountByAge();
        Task<List<ADA_UserSubscriptionWillFinishModel>> UserSubscriptionWillFinish(int futureDays = 5);
        Task<List<ADA_UserSubscriptionCountByPlanModel>> UserSubscriptionCountByPlan();
        Task<List<ADA_TrendingUserSubscriptionsCountModel>> TrendingUserSubscriptionsCount(int topSelect = 5);
        Task<List<ADA_TrendingProductHistoryGetTop10Model>> TrendingProductHistoryGetTop10(int lastXMonth = 3);
        Task<List<ADA_TrendingCategoryModel>> TrendingCategoryGetAll(int days, int top);
        Task<List<ADA_TotalViewsByWeekdaysModel>> TotalViewsByWeekdays();
        Task<List<ADA_TotalViewByRegisterModel>> TotalViewByRegister(int days = 5);
        Task<List<ADA_TotalProductViewByGenderModel>> TotalProductViewByGender();
        Task<List<ADA_TotalCostByPlanModel>> TotalCostByPlan();
        Task<List<ADA_TopUsersViewModel>> TopUsersView(int days, int top);
        Task<List<ADA_TopRateProductModel>> TopRateProducts(int top);
        Task<List<ADA_ProductViewCountModel>> ProductViewCountGetByDays(long productID, int days);
        Task<List<ADA_ProductViewsCountByDaysModel>> ProductViewCountByEveryLastDays(int days);
        Task<List<ADA_PlatformsViewsCountModel>> PlatformsViewsCount(int days);
        Task<List<int>> PendingUsersSubscriptionCount();
        Task<List<ADA_PendingUsersCountModel>> PendingUsersCount();
        Task<List<int>> PendingProductsCount();
        Task<List<int>> PendingAdsPlansCount();
        Task<List<ADA_OSViewsModel>> OSViewsCount(int days);
        Task<List<ADA_LocationViewsCountModel>> LocationViewsCount(int days);
        Task<List<ADA_RegisterUsersViewMonthsModel>> LastXMonthTotalViewByRegister(int lastMonths);
        Task<List<int>> LastMonthsUserJoined(int lastMonths);
        Task<List<int>> LastDaysUserJoined(int days);
        Task<List<ADA_IPAddressViewsModel>> IPViewsCount(int lastDays);
        Task<List<ADA_CategoryViewsByDaysModel>> CategoryViewSumByDays(int lastDays);
        Task<List<ADA_BrowserViewCountModel>> BrowserViewsCount(int lastDays);
        Task<List<ADA_ProductViewCountModel>> AllProductViewCountGetByDays(int days);
        Task<List<ADA_UserSubscriptionWillFinishModel_V2>> UserSubscriptionWillFinishV2(int futureDays = 5);
        public Task<List<ADA_UserSubscriptionCountByPlanModel_V2>> UserSubscriptionCountByPlanV2();


    }
}

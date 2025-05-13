using System.Data;
using EgyptMart.Services.ReportingAPI.Data;
using EgyptMart.Services.ReportingAPI.IRepository;
using EgyptMart.Services.ReportingAPI.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace EgyptMart.Services.ReportingAPI.Repository
{
    public class AdminDashboardRepository(DBMasterContext context) : IAdminDashboardRepository
    {
        public Task<List<ADA_ProductViewCountModel>> AllProductViewCountGetByDays(int days)
        {
            List<SqlParameter> parameters = new(){
                new ("@Days" , SqlDbType.Int) {Value = days }
            };
            return context.Set<ADA_ProductViewCountModel>()
          .FromSqlRaw("EXEC ADA_ALL_ProductView_Count_GetByDays_GET @Days", parameters[0]).ToListAsync();
        }

        public Task<List<ADA_BrowserViewCountModel>> BrowserViewsCount(int lastDays)
        {
            List<SqlParameter> parameters = new(){
                new ("@Days" , SqlDbType.Int) {Value = lastDays }
            };
            return context.Set<ADA_BrowserViewCountModel>()
          .FromSqlRaw("EXEC ADA_BrowserViewsCount_Get @Days", parameters[0]).ToListAsync();
        }

        public Task<List<ADA_CategoryViewsByDaysModel>> CategoryViewSumByDays(int lastDays)
        {
            List<SqlParameter> parameters = new(){
                new ("@Days" , SqlDbType.Int) {Value = lastDays }
            };
            return context.Set<ADA_CategoryViewsByDaysModel>()
          .FromSqlRaw("EXEC ADA_CategoryView_Sum_ByDays_GET @Days", parameters[0]).ToListAsync();
        }

        public Task<List<ADA_IPAddressViewsModel>> IPViewsCount(int lastDays)
        {
            List<SqlParameter> parameters = new(){

                new ("@Days" , SqlDbType.Int) {Value = lastDays }
            };
            return context.Set<ADA_IPAddressViewsModel>()
          .FromSqlRaw("EXEC ADA_IPViewsCount_Get @Days", parameters[0]).ToListAsync();
        }

        public Task<List<int>> LastDaysUserJoined(int days)
        {
            List<SqlParameter> parameters = new(){

                new ("@Days" , SqlDbType.Int) {Value = days }
            };
            return context.Database
          .SqlQueryRaw<int>("EXEC ADA_LastDaysUserJoined_Get @Days", parameters[0]).ToListAsync();
        }

        public Task<List<int>> LastMonthsUserJoined(int lastMonths)
        {
            List<SqlParameter> parameters = new(){

                new ("@Months" , SqlDbType.Int) {Value = lastMonths }
            };
            return context.Database
          .SqlQueryRaw<int>("EXEC ADA_LastMonthsUserJoined_Get @Months", parameters[0]).ToListAsync();
        }

        public Task<List<ADA_RegisterUsersViewMonthsModel>> LastXMonthTotalViewByRegister(int lastMonths)
        {
            List<SqlParameter> parameters = new(){

                new ("@LastMonth" , SqlDbType.Int) {Value = lastMonths }
            };
            return context.Set<ADA_RegisterUsersViewMonthsModel>()
          .FromSqlRaw("EXEC ADA_LastXMonthTotalViewByRegister_GET @LastMonth", parameters[0]).ToListAsync();
        }

        public Task<List<ADA_LocationViewsCountModel>> LocationViewsCount(int days)
        {
            List<SqlParameter> parameters = new(){

                new ("@Days" , SqlDbType.Int) {Value = days }
            };
            return context.Set<ADA_LocationViewsCountModel>()
          .FromSqlRaw("EXEC ADA_LocationViewsCount_Get @Days", parameters[0]).ToListAsync();
        }

        public Task<List<ADA_OSViewsModel>> OSViewsCount(int days)
        {
            List<SqlParameter> parameters = new(){

                new ("@Days" , SqlDbType.Int) {Value = days }
            };
            return context.Set<ADA_OSViewsModel>()
          .FromSqlRaw("EXEC ADA_OSViewsCount_Get @Days", parameters[0]).ToListAsync();
        }

        public Task<List<int>> PendingAdsPlansCount()
        {
            return context.Database.SqlQueryRaw<int>("EXEC ADA_PendingAdsPlansCount_Get").ToListAsync();
        }

        public Task<List<int>> PendingProductsCount()
        {
            return context.Database.SqlQueryRaw<int>("EXEC ADA_PendingProductsCount_Get").ToListAsync();

        }

        public Task<List<ADA_PendingUsersCountModel>> PendingUsersCount()
        {
            return context.Set<ADA_PendingUsersCountModel>()
                    .FromSqlRaw("EXEC ADA_PendingUsersCount_Get").ToListAsync();

        }

        public Task<List<int>> PendingUsersSubscriptionCount()
        {
            return context.Database.SqlQueryRaw<int>("EXEC ADA_PendingUsersSubscriptionCount_Get").ToListAsync();
        }

        public Task<List<ADA_PlatformsViewsCountModel>> PlatformsViewsCount(int days)
        {
            List<SqlParameter> parameters = new(){

                new ("@Days" , SqlDbType.Int) {Value = days }
            };
            return context.Set<ADA_PlatformsViewsCountModel>()
          .FromSqlRaw("EXEC ADA_PlatformsViewsCount_Get @Days", parameters[0]).ToListAsync();
        }

        public Task<List<ADA_ProductViewsCountByDaysModel>> ProductViewCountByEveryLastDays(int days)
        {
            List<SqlParameter> parameters = new(){

                new ("@Days" , SqlDbType.Int) {Value = days }
            };
            return context.Set<ADA_ProductViewsCountByDaysModel>()
          .FromSqlRaw("EXEC ADA_PoductViewCountByEveryLastDays_Get @Days", parameters[0]).ToListAsync();
        }

        public Task<List<ADA_ProductViewCountModel>> ProductViewCountGetByDays(long productID, int days)
        {
            List<SqlParameter> parameters = new(){
                new ("@ProductID" , SqlDbType.BigInt) {Value = productID  },
                new ("@Days" , SqlDbType.Int) {Value = days }
            };
            return context.Set<ADA_ProductViewCountModel>()
          .FromSqlRaw("EXEC ADA_ProductView_Count_GetByDays_GET @ProductID , @Days", parameters[0], parameters[1]).ToListAsync();
        }

        public Task<List<ADA_TopRateProductModel>> TopRateProducts(int top)
        {
            List<SqlParameter> parameters = new(){
                new ("@Top" , SqlDbType.Int) {Value = top }
            };
            return context.Set<ADA_TopRateProductModel>()
          .FromSqlRaw("EXEC ADA_TopRateProducts_Get @Top", parameters[0]).ToListAsync();
        }

        public Task<List<ADA_TopUsersViewModel>> TopUsersView(int days, int top)
        {
            List<SqlParameter> parameters = new(){
                new ("@Days" , SqlDbType.Int) {Value = days },
                new ("@Top" , SqlDbType.Int) {Value = top }
            };
            return context.Set<ADA_TopUsersViewModel>()
            .FromSqlRaw("EXEC ADA_TopUsersView_Get @Days, @Top", parameters[0], parameters[1]).ToListAsync();
        }

        public Task<List<ADA_TotalCostByPlanModel>> TotalCostByPlan()
        {
            return context.Set<ADA_TotalCostByPlanModel>()
      .FromSqlRaw("EXEC ADA_TotalCostByPlan_Get ").ToListAsync();
        }

        public Task<List<ADA_TotalProductViewByGenderModel>> TotalProductViewByGender()
        {
            return context.Set<ADA_TotalProductViewByGenderModel>()
       .FromSqlRaw("EXEC ADA_TotalProductViewByGender_GET ").ToListAsync();
        }

        public Task<List<ADA_TotalViewByRegisterModel>> TotalViewByRegister(int days = 5)
        {
            List<SqlParameter> parameters = new(){
                new ("@Days" , SqlDbType.Int) {Value = days }
            };
            return context.Set<ADA_TotalViewByRegisterModel>()
          .FromSqlRaw("EXEC ADA_TotalViewByRegister_GET @Days", parameters[0]).ToListAsync();
        }

        public Task<List<ADA_TotalViewsByWeekdaysModel>> TotalViewsByWeekdays()
        {
            return context.Set<ADA_TotalViewsByWeekdaysModel>()
          .FromSqlRaw("EXEC ADA_TotalViewsByWeekdays_GET").ToListAsync();
        }

        public Task<List<ADA_TrendingCategoryModel>> TrendingCategoryGetAll(int days, int top)
        {
            List<SqlParameter> parameters = new(){
                new ("@Days" , SqlDbType.Int) {Value = days },
                new ("@Top" , SqlDbType.Int) {Value = top }
            };
            return context.Set<ADA_TrendingCategoryModel>()
            .FromSqlRaw("EXEC ADA_TrendingCategory_GetAll @Days, @Top", parameters[0], parameters[1]).ToListAsync();
        }

        public Task<List<ADA_TrendingProductHistoryGetTop10Model>> TrendingProductHistoryGetTop10(int lastXMonth = 3)
        {
            List<SqlParameter> parameters = new(){
                new ("@LastXMonth" , SqlDbType.Int) {Value = lastXMonth }
            };
            return context.Set<ADA_TrendingProductHistoryGetTop10Model>()
            .FromSqlRaw("EXEC ADA_TrendingProduct_History_GetTop10 @LastXMonth", parameters[0]).ToListAsync();
        }

        public Task<List<ADA_TrendingUserSubscriptionsCountModel>> TrendingUserSubscriptionsCount(int topSelect = 5)
        {
            List<SqlParameter> parameters = new(){
                new ("@Top" , SqlDbType.Int) {Value = topSelect }
            };
            return context.Set<ADA_TrendingUserSubscriptionsCountModel>()
                .FromSqlRaw("EXEC ADA_TrendingUserSubscriptionsCount_Get @Top", parameters[0]).ToListAsync();
        }

        public Task<List<ADA_UserSubscriptionCountByPlanModel>> UserSubscriptionCountByPlan()
        {
            return context.Set<ADA_UserSubscriptionCountByPlanModel>()
               .FromSqlRaw("EXEC ADA_UserSubscriptionCountByPlan_GET").ToListAsync();
        }

        public Task<List<ADA_UserSubscriptionWillFinishModel>> UserSubscriptionWillFinish(int futureDays = 5)
        {
            List<SqlParameter> parameters = new(){
                new ("@Days" , SqlDbType.Int) {Value = futureDays }
            };
            return context.Set<ADA_UserSubscriptionWillFinishModel>()
                .FromSqlRaw("EXEC ADA_UserSubscriptionWillFinish_GET @Days", parameters[0]).ToListAsync();
        }

        public Task<List<ADA_UserSubscriptionWillFinishModel_V2>> UserSubscriptionWillFinishV2(int futureDays = 5)
        {
            List<SqlParameter> parameters = new(){
                new ("@Days" , SqlDbType.Int) {Value = futureDays }
            };
            return context.Set<ADA_UserSubscriptionWillFinishModel_V2>()
                .FromSqlRaw("EXEC ADA_UserSubscriptionWillFinish_GET_V2 @Days", parameters[0]).ToListAsync();
        }


        public Task<List<ADA_ViewCountByAgeModel>> ViewCountByAge()
        {
            return context.Set<ADA_ViewCountByAgeModel>()
            
                .FromSqlRaw("EXEC ADA_ViewCountByAge_GET").ToListAsync();
        }

        public Task<List<ADA_UserSubscriptionCountByPlanModel_V2>> UserSubscriptionCountByPlanV2()
        {
            return context.Set<ADA_UserSubscriptionCountByPlanModel_V2>()
             .FromSqlRaw("EXEC ADA_UserSubscriptionCountByPlan_GET_V2").ToListAsync();
        }
    }
}

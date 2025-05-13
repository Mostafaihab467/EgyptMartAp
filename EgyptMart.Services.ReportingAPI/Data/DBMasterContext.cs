
using EgyptMart.Services.ReportingAPI.DTO;
using EgyptMart.Services.ReportingAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace EgyptMart.Services.ReportingAPI.Data;

public partial class DBMasterContext : DbContext
{
    public DBMasterContext(DbContextOptions options)
    : base(options)
    {
    }
    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);



    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //{addLineAfter-2} 


        #region Admin Dashboard Models

        modelBuilder.Entity<ADA_ViewCountByAgeModel>(b => b.HasNoKey());
        modelBuilder.Entity<ADA_UserSubscriptionWillFinishModel>(b => b.HasNoKey());
        modelBuilder.Entity<ADA_UserSubscriptionCountByPlanModel>(b => b.HasNoKey());
        modelBuilder.Entity<ADA_TrendingUserSubscriptionsCountModel>(b => b.HasNoKey());
        modelBuilder.Entity<ADA_TrendingProductHistoryGetTop10Model>(b => b.HasNoKey());
        modelBuilder.Entity<ADA_TrendingCategoryModel>(b => b.HasNoKey());
        modelBuilder.Entity<ADA_TotalViewsByWeekdaysModel>(b => b.HasNoKey());
        modelBuilder.Entity<ADA_TotalViewByRegisterModel>(b => b.HasNoKey());
        modelBuilder.Entity<ADA_TotalProductViewByGenderModel>(b => b.HasNoKey());
        modelBuilder.Entity<ADA_TotalCostByPlanModel>(b => b.HasNoKey());
        modelBuilder.Entity<ADA_TopUsersViewModel>(b => b.HasNoKey());
        modelBuilder.Entity<ADA_TopRateProductModel>(b => b.HasNoKey());
        modelBuilder.Entity<ADA_ProductViewCountModel>(b => b.HasNoKey());
        modelBuilder.Entity<ADA_ProductViewsCountByDaysModel>(b => b.HasNoKey());
        modelBuilder.Entity<ADA_PlatformsViewsCountModel>(b => b.HasNoKey());
        modelBuilder.Entity<ADA_PendingUsersCountModel>(b => b.HasNoKey());
        modelBuilder.Entity<ADA_OSViewsModel>(b => b.HasNoKey());
        modelBuilder.Entity<ADA_LocationViewsCountModel>(b => b.HasNoKey());
        modelBuilder.Entity<ADA_RegisterUsersViewMonthsModel>(b => b.HasNoKey());
        modelBuilder.Entity<ADA_IPAddressViewsModel>(b => b.HasNoKey());
        modelBuilder.Entity<ADA_CategoryViewsByDaysModel>(b => b.HasNoKey());
        modelBuilder.Entity<ADA_BrowserViewCountModel>(b => b.HasNoKey());

        #endregion

        #region Supplier
        modelBuilder.Entity<SDA_AdsSubscriptionStatusDto>(entity => { entity.HasNoKey(); });
        modelBuilder.Entity<SDA_CategoryWithProductCountDto>(entity => { entity.HasNoKey(); });
        modelBuilder.Entity<SDA_OutOfStockProductDto>(entity => { entity.HasNoKey(); });
        modelBuilder.Entity<SDA_ProductReviewDto>(entity => { entity.HasNoKey(); });
        modelBuilder.Entity<SDA_ProductViewCountDto>(entity => { entity.HasNoKey(); });
        modelBuilder.Entity<SDA_ProductViewCountLastXDaysDto>(entity => { entity.HasNoKey(); });
        modelBuilder.Entity<SDA_TopRatedProductDto>(entity => { entity.HasNoKey(); });
        modelBuilder.Entity<SDA_TopUserViewDto>(entity => { entity.HasNoKey(); });
        modelBuilder.Entity<SDA_TotalProductViewByGenderDto>(entity => { entity.HasNoKey(); });
        modelBuilder.Entity<SDA_TotalViewsByRegisterDto>(entity => { entity.HasNoKey(); });
        modelBuilder.Entity<SDA_TotalViewsByWeekdayDto>(entity => { entity.HasNoKey(); });
        modelBuilder.Entity<SDA_TrendingCategoryDto>(entity => { entity.HasNoKey(); });
        modelBuilder.Entity<SDA_TrendingProduct_History_GetByLast4MonthsDto>(entity => { entity.HasNoKey(); });
        modelBuilder.Entity<SDA_TrendingProductDto>(entity => { entity.HasNoKey(); });
        modelBuilder.Entity<SDA_TrendingProductInsertDto>(entity => { entity.HasNoKey(); });
        modelBuilder.Entity<SDA_ViewCountByAgeDto>(entity => { entity.HasNoKey(); });
        #endregion
        OnModelCreatingPartial(modelBuilder);
    }

}

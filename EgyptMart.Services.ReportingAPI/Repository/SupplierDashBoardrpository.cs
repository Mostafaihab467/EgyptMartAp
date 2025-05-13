using System.Data;
using EgyptMart.Services.ReportingAPI.Data;
using EgyptMart.Services.ReportingAPI.DTO;
using EgyptMart.Services.ReportingAPI.IRepository;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace EgyptMart.Services.ReportingAPI.Repository
{
    public class SupplierDashBoardrpository : ISupplierDashBoardrpository
    {

        DBMasterContext _context;

        public SupplierDashBoardrpository(DBMasterContext context)
        {
            this._context = context;
        }


        public async Task<List<SDA_ViewCountByAgeDto>> ViewCountByAgeget(int SupplierID)
        {
            var parameters = new List<SqlParameter>
            {
                new SqlParameter("@SupplierID", SqlDbType.Int) { Value = SupplierID },

            };


            var result = await _context.Set<SDA_ViewCountByAgeDto>().FromSqlRaw(
                "EXEC SDA_ViewCountByAge_GET  @SupplierID",
                parameters.ToArray()
            ).ToListAsync();


            return result;
        }

        public async Task<int> TrendingProductInsertDto(SDA_TrendingProductInsertDto dto)
        {
            var parameters = new List<SqlParameter>
    {
        new SqlParameter("@OwnerID", SqlDbType.BigInt) { Value = dto.OwnerID },
        new SqlParameter("@ProductID", SqlDbType.BigInt) { Value = dto.ProductID },
        new SqlParameter("@CategoryID", SqlDbType.BigInt) { Value = dto.CategoryID },
        new SqlParameter("@ProductTitle", SqlDbType.NVarChar, 250) { Value = dto.ProductTitle },
        new SqlParameter("@ViewCount", SqlDbType.BigInt) { Value = dto.ViewCount }
    };

            var result = await _context.Database.ExecuteSqlRawAsync(
                 "EXEC [dbo].[SDA_TrendingProduct_Insert] @OwnerID, @ProductID, @CategoryID, @ProductTitle, @ViewCount",
                 parameters.ToArray()
             );

            return result;
        }

        public async Task<List<SDA_TrendingProduct_History_GetByLast4MonthsDto>> TrendingProduct_History_GetByLast4Months(long productId, long ownerId)
        {
            var parameters = new List<SqlParameter>
                {
                    new SqlParameter("@ProductID", SqlDbType.BigInt) { Value = productId },
                    new SqlParameter("@OwnerID", SqlDbType.BigInt) { Value = ownerId }
                };

            var result = await _context.Set<SDA_TrendingProduct_History_GetByLast4MonthsDto>().FromSqlRaw(
                "EXEC [dbo].[SDA_TrendingProduct_History_GetByLast4Months] @ProductID, @OwnerID",
                parameters.ToArray()
            ).ToListAsync();

            return result;
        }

        public async Task<List<SDA_TrendingProductDto>> GetTopTrendingProductsAsync(int days, long ownerId, int top = 5, byte LangID = 1)
        {
            var parameters = new List<SqlParameter>
            {
                new SqlParameter("@Days", SqlDbType.Int) { Value = days },
                new SqlParameter("@OwnerID", SqlDbType.BigInt) { Value = ownerId },
                new SqlParameter("@Top", SqlDbType.Int) { Value = top },
                new SqlParameter("@LangID", SqlDbType.Int) { Value = LangID }
            };

            var result = await _context.Set<SDA_TrendingProductDto>().FromSqlRaw(
                "EXEC [dbo].[SDA_TrendingProduct_GetTopByOwner] @Days, @OwnerID, @Top , @LangID",
                parameters.ToArray()
            ).ToListAsync();

            return result;
        }


        public async Task<List<SDA_TrendingCategoryDto>> GetTrendingCategoriesByOwnerAsync(long ownerId, int days = 30, int top = 5, byte LangID = 1)
        {
            var parameters = new[]
            {
            new SqlParameter("@OwnerID", SqlDbType.BigInt) { Value = ownerId },
            new SqlParameter("@Days", SqlDbType.Int) { Value = days },
            new SqlParameter("@Top", SqlDbType.Int) { Value = top },
            new SqlParameter("@LangID", SqlDbType.TinyInt) { Value = LangID }
        };

            var result = await _context.Set<SDA_TrendingCategoryDto>()
                .FromSqlRaw("EXEC SDA_TrendingCategory_GetByOwner @OwnerID, @Days, @Top , @LangID", parameters)
                .ToListAsync();

            return result;
        }


        public async Task<List<SDA_TotalViewsByWeekdayDto>> GetTotalViewsByWeekdaysAsync(long supplierId, byte LangID)
        {
            var parameters = new[]
            {
                new SqlParameter("@SupplierID", SqlDbType.BigInt) { Value = supplierId },
                new SqlParameter("@LangID", SqlDbType.TinyInt) { Value = LangID }
            };

            var result = await _context.Set<SDA_TotalViewsByWeekdayDto>()
                .FromSqlRaw("EXEC SDA_TotalViewsByWeekdays_GET @SupplierID ,@LangID", parameters)
                .ToListAsync();

            return result;
        }

        // error on procedure with AMR
        public async Task<List<SDA_TotalViewsByRegisterDto>> GetTotalViewsByRegisterAsync(long OwnerID, int days, int top = 5)
        {
            var parameters = new[]
            {
            new SqlParameter("@OwnerID ", SqlDbType.BigInt) { Value = OwnerID  },
            new SqlParameter("@@Days ", SqlDbType.BigInt) { Value = days  },
            new SqlParameter("@Top", DbType.Int32) { Value = top }
    };

            var result = await _context.Set<SDA_TotalViewsByRegisterDto>()
                .FromSqlRaw("EXEC SDA_TotalViewCountByRegister_GET @OwnerID , @Top", parameters)
                .ToListAsync();

            return result;
        }

        public async Task<List<SDA_TotalProductViewByGenderDto>> GetTotalProductViewByGenderAsync(long ownerId)
        {
            var parameters = new[]
            {
        new SqlParameter("@OwnerID", SqlDbType.BigInt) { Value = ownerId }
    };

            var result = await _context.Set<SDA_TotalProductViewByGenderDto>()
                .FromSqlRaw("EXEC SDA_TotalProductViewByGender_GET @OwnerID", parameters)
                .ToListAsync();

            return result;
        }

        public async Task<List<SDA_TopUserViewDto>> GetTopUsersViewAsync(long supplierId, int top = 5, int lastDays = 3)
        {
            var parameters = new[]
            {
        new SqlParameter("@SupplierID", SqlDbType.BigInt) { Value = supplierId },
        new SqlParameter("@Top", SqlDbType.Int) { Value = top },
        new SqlParameter("@LastDays", SqlDbType.Int) { Value = lastDays }
    };

            var result = await _context.Set<SDA_TopUserViewDto>()
                .FromSqlRaw("EXEC SDA_TopUsersView_Get @SupplierID, @Top, @LastDays", parameters)
                .ToListAsync();

            return result;
        }

        public async Task<List<SDA_TopRatedProductDto>> GetTopRatedProductsAsync(long ownerId, int top = 5, byte langID = 1)
        {
            var parameters = new[]
            {
        new SqlParameter("@OwnerID", SqlDbType.BigInt) { Value = ownerId },
        new SqlParameter("@Top", SqlDbType.Int) { Value = top },
        new SqlParameter("@LangID", SqlDbType.TinyInt) { Value = langID },
    };

            var result = await _context.Set<SDA_TopRatedProductDto>()
                .FromSqlRaw("EXEC SDA_TopRateProducts_Get @OwnerID, @Top, @LangID", parameters)
                .ToListAsync();

            return result;
        }

        public async Task<int> UpdateProductViewCountAsync(long productId)
        {
            var parameter = new SqlParameter("@ProductID", SqlDbType.BigInt) { Value = productId };

            int affectedRows = await _context.Database.ExecuteSqlRawAsync("EXEC SDA_ProductViewCount_Update @ProductID", parameter);

            return affectedRows;
        }

        public async Task<List<SDA_ProductViewCountDto>> GetProductViewCountByDaysAsync(long productId, int days)
        {
            var parameters = new[]
            {
        new SqlParameter("@ProductID", SqlDbType.BigInt) { Value = productId },
        new SqlParameter("@Days", SqlDbType.Int) { Value = days }
    };

            var result = await _context.Set<SDA_ProductViewCountDto>()
                .FromSqlRaw("EXEC SDA_ProductView_Count_GetByDays_GET @ProductID, @Days", parameters)

                .ToListAsync();


            return result;
        }

        public async Task<List<SDA_ProductReviewDto>> GetTopReviewedProductsAsync(long ownerId, bool orderByDesc, byte langId)
        {
            var parameters = new[]
            {
                new SqlParameter("@OwnerID", SqlDbType.BigInt) { Value = ownerId },
                new SqlParameter("@OrderBy", SqlDbType.Bit) { Value = orderByDesc },
                new SqlParameter("@LangID", SqlDbType.TinyInt) { Value = langId },
            };

            return await _context.Set<SDA_ProductReviewDto>()
                .FromSqlRaw("EXEC SDA_Products_TopReviews_Get @OwnerID, @OrderBy , @LangID", parameters)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<List<SDA_OutOfStockProductDto>> GetOutOfStockProductsAsync(long ownerId)
        {
            var parameters = new[]
            {
        new SqlParameter("@OwnerID", SqlDbType.BigInt) { Value = ownerId }
    };

            return await _context.Set<SDA_OutOfStockProductDto>()
                .FromSqlRaw("EXEC SDA_Products_OutOfStock_Get @OwnerID", parameters)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<List<SDA_ProductViewCountLastXDaysDto>> GetProductViewCountByLastDaysAsync(long ownerId, int days)
        {
            var parameters = new[]
            {
        new SqlParameter("@OwnerID", SqlDbType.BigInt) { Value = ownerId },
        new SqlParameter("@Days", SqlDbType.Int) { Value = days }
    };

            return await _context.Set<SDA_ProductViewCountLastXDaysDto>()
                .FromSqlRaw("EXEC SDA_PoductViewCountByEveryLastDays_Get @OwnerID, @Days", parameters)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<List<SDA_CategoryWithProductCountDto>> GetCategoryProductCountsAsync(long ownerId, byte langId)
        {
            var parameter = new[] {
                new SqlParameter("@OwnerID", SqlDbType.BigInt) { Value = ownerId },
                new SqlParameter("@langId", SqlDbType.TinyInt) { Value = langId }
            };

            return await _context.Set<SDA_CategoryWithProductCountDto>()
                .FromSqlRaw("EXEC SDA_CategoryWithProductCount_Get @OwnerID ,@langId", parameter.ToArray())
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<List<SDA_AdsSubscriptionStatusDto>> GetAdsSubscriptionStatusAsync(long userId)
        {
            var parameter = new SqlParameter("@UserID", SqlDbType.BigInt) { Value = userId };

            return await _context.Set<SDA_AdsSubscriptionStatusDto>()
                .FromSqlRaw("EXEC SDA_AdsSubscriptionsStatus_GetCount @UserID", parameter)
                .AsNoTracking()
                .ToListAsync();
        }

    }
}

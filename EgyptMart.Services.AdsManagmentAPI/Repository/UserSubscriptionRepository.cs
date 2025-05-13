using System.Data;
using EgyptMart.Services.AdsManagmentAPI.Data;
using EgyptMart.Services.AdsManagmentAPI.DTO;
using EgyptMart.Services.AdsManagmentAPI.IRepository;
using EgyptMart.Services.AdsManagmentAPI.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace EgyptMart.Services.AdsManagmentAPI.Repository
{
    public class UserSubscriptionRepository(DBMasterContext context) : IUserSubscriptionRepository
    {
        public Task<List<UserMySubscriptionModel>> MySubscriptionsGet(long userID, byte langID = 1)
        {
            List<SqlParameter> parameter = [
                new("@UserID", SqlDbType.BigInt) { Value = userID },
                new("@LangID", SqlDbType.TinyInt) { Value = langID },
                ];
            return context.UserMySubscriptionModel.FromSqlRaw("Ads_UsersSubscriptions_GetMyList @UserID, @LangID", [.. parameter]).ToListAsync();
        }


        public Task<List<UserMySubscriptionModel>> UserSubscriptionByLocation(long locationID)
        {
            SqlParameter parameter = new("@LocationID", SqlDbType.BigInt) { Value = locationID };
            return context.UserMySubscriptionModel.FromSqlRaw("Ads_UsersSubscriptions_GetByLocation @LocationID", parameter).ToListAsync();
        }

        public Task<int> Subscribe(UserSubscriptionsCreateDTO dto, string ImageUrl)
        {
            List<SqlParameter> sqlParameters = [
                         new SqlParameter("@UserID", SqlDbType.BigInt) { Value = dto.UserID },
                    new SqlParameter("@PlanID", SqlDbType.BigInt) { Value = dto.PlanID },
                    new SqlParameter("@AdsImageUrl", SqlDbType.NVarChar) { Value = ImageUrl },
                    new SqlParameter("@StartDate", SqlDbType.Date) { Value = dto.StartDate },
                    new SqlParameter("@EndDate", SqlDbType.Date) { Value = dto.EndDate },
                    new SqlParameter("@Cost", SqlDbType.Decimal) { Value = dto.Cost },
                    new SqlParameter("@TargetURL", SqlDbType.NVarChar) { Value = dto.TargetURL }
                 ];

            return context.Database.ExecuteSqlRawAsync("EXEC Ads_UsersSubscriptions_Create @UserID, @PlanID, @AdsImageUrl, @StartDate, @EndDate, @Cost, @TargetURL", [.. sqlParameters]);
        }



        public Task<int> EditUserSubscription(long subscriptionID, UpdateUserSubscriptionDTO dto)
        {
            List<SqlParameter> sqlParameters = [

                        new SqlParameter("@SubscribtionID", SqlDbType.BigInt) { Value = subscriptionID },
                new SqlParameter("@AdsImageUrl", SqlDbType.NVarChar) { Value = dto.AdsImageUrl },
                new SqlParameter("@StartDate", SqlDbType.Date) { Value = dto.StartDate },
                new SqlParameter("@EndDate", SqlDbType.Date) { Value = dto.EndDate },
                new SqlParameter("@TargetURL", SqlDbType.NVarChar) { Value = dto.TargetURL },

            ];

            return context.Database.ExecuteSqlRawAsync("EXEC Ads_UsersSubscriptions_Edit @SubscribtionID, @AdsImageUrl, @StartDate, @EndDate, @TargetURL", sqlParameters);

        }

        public Task<int> MySubscriptionChangeStatus(long subscriptionID, bool isActive)
        {
            List<SqlParameter> sqlParameters = [
                     new SqlParameter("@SubscribtionID", SqlDbType.BigInt) { Value = subscriptionID },
                new SqlParameter("@IsActive", SqlDbType.Bit) { Value = isActive },
            ];

            return context.Database.ExecuteSqlRawAsync("EXEC Ads_UsersSubscriptions_ChangeStatus @SubscribtionID, @IsActive", sqlParameters);
        }
    }
}

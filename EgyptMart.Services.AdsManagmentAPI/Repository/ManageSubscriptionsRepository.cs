using System.Data;
using EgyptMart.Services.AdsManagmentAPI.Data;
using EgyptMart.Services.AdsManagmentAPI.DTO;
using EgyptMart.Services.AdsManagmentAPI.IRepository;
using EgyptMart.Services.AdsManagmentAPI.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace EgyptMart.Services.AdsManagmentAPI.Repository
{
    public class ManageSubscriptionsRepository(DBMasterContext context) : IManageSubscriptionsRepository
    {

        public async Task<List<AdsLocationsListModel>> GetAdsLubLocationsList()
        {
            return await context.AdsLocationsListModel.FromSqlRaw("Ads_Lup_LocationsList_GetList").ToListAsync();
        }


        public Task<List<SubscribtionCreateModel>> CreateSubscription(CreateSubscriptionDTO dto)
        {
            SqlParameter planTitleParam = new SqlParameter("@PlanTitle", SqlDbType.NVarChar, 255) { Value = dto.PlanTitle.Trim() };

            SqlParameter locationIdParam = new SqlParameter("@LocationID", SqlDbType.SmallInt) { Value = dto.LocationID };

            SqlParameter durationDaysParam = new SqlParameter("@DurationDays", SqlDbType.TinyInt) { Value = dto.DurationDays };

            SqlParameter costBeforeParam = new SqlParameter("@CostBefore", SqlDbType.Decimal) { Value = dto.CostBefore };

            SqlParameter costParam = new SqlParameter("@Cost", SqlDbType.Decimal) { Value = dto.Cost };

            SqlParameter planDescriptionParam = new SqlParameter("@PlanDescription", SqlDbType.NVarChar) { Value = dto.PlanDescription.Trim() };

            SqlParameter langIdParam = new SqlParameter("@LangID", SqlDbType.TinyInt) { Value = dto.LangID };

            SqlParameter basePlanParam = new SqlParameter("@BasePlanID", SqlDbType.BigInt) { Value = dto.BasePlanID };

            return context.SubscribtionCreateModel.FromSqlRaw(
            "EXEC Ads_SubscriptionPlans_Create  @PlanTitle, @LocationID, @DurationDays, @CostBefore, @Cost, @PlanDescription , @LangID , @BasePlanID",
             planTitleParam, locationIdParam, durationDaysParam, costBeforeParam, costParam, planDescriptionParam, langIdParam, basePlanParam).ToListAsync(); ;

        }

        public Task<int> EditSubscription(long adsPlanId, EditSubscriptionDTO dto)
        {
            SqlParameter adsPlanIdParam = new("@AdsPlanId", SqlDbType.BigInt) { Value = adsPlanId };

            SqlParameter planTitleParam = new SqlParameter("@PlanTitle", SqlDbType.NVarChar, 255) { Value = dto.PlanTitle.Trim() };

            SqlParameter locationIdParam = new SqlParameter("@LocationID", SqlDbType.SmallInt) { Value = dto.LocationID };

            SqlParameter durationDaysParam = new SqlParameter("@DurationDays", SqlDbType.TinyInt) { Value = dto.DurationDays };

            SqlParameter costBeforeParam = new SqlParameter("@CostBefore", SqlDbType.Decimal) { Value = dto.CostBefore };

            SqlParameter costParam = new SqlParameter("@Cost", SqlDbType.Decimal) { Value = dto.Cost };

            SqlParameter planDescriptionParam = new SqlParameter("@PlanDescription", SqlDbType.NVarChar) { Value = dto.PlanDescription.Trim() };

            return context.Database.ExecuteSqlRawAsync(
            "EXEC Ads_SubscriptionPlans_Edit @AdsPlanID, @PlanTitle, @LocationID, @DurationDays, @CostBefore, @Cost, @PlanDescription",
            adsPlanIdParam, planTitleParam, locationIdParam, durationDaysParam, costBeforeParam, costParam, planDescriptionParam
        );
        }


        public Task<List<SubscriptionsListModel>> GetSubscriptionsList(byte repType, byte langID = 1)
        {
            List<SqlParameter> parameter = [

                new SqlParameter("@RepType", SqlDbType.TinyInt)
            {
                Value = repType
            },  new SqlParameter("@LangID", SqlDbType.TinyInt)
            {
                Value = langID
            },

            ];
            return context
                    .SubscriptionsLisModel
                    .FromSqlRaw($"Exec Ads_SubscriptionPlans_Get @RepType , @LangID", [.. parameter])
                    .ToListAsync();
        }

        public Task<int> SetSubscriptionStatus(long adsPlanId, bool isActive)
        {
            SqlParameter adsPlanIdParam = new SqlParameter("@AdsPlanId", SqlDbType.BigInt);
            adsPlanIdParam.Value = adsPlanId;

            SqlParameter adsIsActiveParam = new SqlParameter("@IsActive", SqlDbType.Bit);
            adsIsActiveParam.Value = isActive;

            return context.Database.ExecuteSqlRawAsync($"Exec Ads_SubscriptionPlans_SetStatus @AdsPlanId , @IsActive", adsPlanIdParam, adsIsActiveParam);
        }

        public Task<List<SubscribtionCreateModel>> CreateTranslatedSubscription(CreateTranslatedSubscriptionDTO dto)
        {
            List<SqlParameter> listParams = [
            new SqlParameter("@PlanTitle", SqlDbType.NVarChar) { Value = dto.PlanTitle.Trim() },

                new SqlParameter("@PlanDescription", SqlDbType.NVarChar) { Value = dto.PlanDescription.Trim() },

                new SqlParameter("@LangID", SqlDbType.TinyInt) { Value = dto.LangID },

                new SqlParameter("@BasePlanID", SqlDbType.BigInt) { Value = dto.BasePlanID }
            ];

            return context.SubscribtionCreateModel.FromSqlRaw(
            "EXEC Ads_SubscriptionPlans_Translate  @PlanTitle, @PlanDescription , @LangID , @BasePlanID",
           listParams[0], listParams[1], listParams[2], listParams[3]).ToListAsync();
        }

        public Task<List<SubscriptionsListModel>> GetTranslateByLangId(long basePlanID, byte langID)
        {


            List<SqlParameter> sqlParams = [
                 new SqlParameter("@BasiID", SqlDbType.BigInt) { Value = basePlanID },
                new SqlParameter("@LangID", SqlDbType.TinyInt) { Value = langID }
                ];

            return context
                    .SubscriptionsLisModel
                    .FromSqlRaw($"Exec Ads_SubscriptionPlans_GetByLang @BasiID, @LangID", sqlParams[0], sqlParams[1])
                    .ToListAsync();
        }

        public Task<List<SubscriptionsListModel>> GetSubscriptionByID(long subscriptionID)
        {
            List<SqlParameter> sqlParams = [
              new SqlParameter("@AdsPlanID", SqlDbType.BigInt) { Value = subscriptionID }
             ];

            return context
                    .SubscriptionsLisModel
                    .FromSqlRaw($"Exec Ads_SubscriptionPlans_GetByID @AdsPlanID", sqlParams[0])
                    .ToListAsync();
        }



    }
}

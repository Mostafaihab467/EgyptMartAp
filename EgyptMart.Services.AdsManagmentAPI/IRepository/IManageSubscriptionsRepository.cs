using EgyptMart.Services.AdsManagmentAPI.DTO;
using EgyptMart.Services.AdsManagmentAPI.Models;

namespace EgyptMart.Services.AdsManagmentAPI.IRepository
{
    public interface IManageSubscriptionsRepository
    {
        public Task<List<AdsLocationsListModel>> GetAdsLubLocationsList();
        public Task<List<SubscribtionCreateModel>> CreateSubscription(CreateSubscriptionDTO dto);
        public Task<List<SubscribtionCreateModel>> CreateTranslatedSubscription(CreateTranslatedSubscriptionDTO dto);
        public Task<int> EditSubscription(long adsPlanId, EditSubscriptionDTO dto);
        public Task<List<SubscriptionsListModel>> GetSubscriptionsList(byte repType, byte langID = 1);
        public Task<List<SubscriptionsListModel>> GetSubscriptionByID(long subscriptionID);
        public Task<List<SubscriptionsListModel>> GetTranslateByLangId(long basePlanID, byte langID);

        public Task<int> SetSubscriptionStatus(long adsPlanId, bool isActive);

    }
}

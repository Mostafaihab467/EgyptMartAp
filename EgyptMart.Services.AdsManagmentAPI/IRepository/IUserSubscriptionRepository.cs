using EgyptMart.Services.AdsManagmentAPI.DTO;
using EgyptMart.Services.AdsManagmentAPI.Models;

namespace EgyptMart.Services.AdsManagmentAPI.IRepository
{
    public interface IUserSubscriptionRepository
    {
        public Task<int> Subscribe(UserSubscriptionsCreateDTO dto, string imageURL);
        public Task<List<UserMySubscriptionModel>> MySubscriptionsGet(long userID, byte langID = 1);
        public Task<List<UserMySubscriptionModel>> UserSubscriptionByLocation(long locationID);
        public Task<int> EditUserSubscription(long subscriptionID, UpdateUserSubscriptionDTO dto);
        public Task<int> MySubscriptionChangeStatus(long subscriptionID, bool isActive);
    }
}

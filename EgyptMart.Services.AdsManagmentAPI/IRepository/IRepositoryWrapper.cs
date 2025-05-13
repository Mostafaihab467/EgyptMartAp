
namespace EgyptMart.Services.AdsManagmentAPI.IRepository
{
    public interface IRepositoryWrapper
    {

        public IManageSubscriptionsRepository ManageSubscriptionsRepository { get; }
        public IUserSubscriptionRepository UserSubscriptionsRepository { get; }
    }
}


using EgyptMart.Services.AdsManagmentAPI.Data;
using EgyptMart.Services.AdsManagmentAPI.IRepository;

namespace EgyptMart.Services.AdsManagmentAPI.Repository
{
    public class RepositoryWrapper(DBMasterContext context) : IRepositoryWrapper
    {

        private IManageSubscriptionsRepository _ManageSubscriptionsRepository;
        private IUserSubscriptionRepository _usersSubscriptionsRepository;

        public IManageSubscriptionsRepository ManageSubscriptionsRepository
        {
            get
            {
                _ManageSubscriptionsRepository ??= new ManageSubscriptionsRepository(context);
                return _ManageSubscriptionsRepository;
            }
        }

        public IUserSubscriptionRepository UserSubscriptionsRepository
        {
            get
            {
                _usersSubscriptionsRepository ??= new UserSubscriptionRepository(context);
                return _usersSubscriptionsRepository;
            }
        }
    }
}

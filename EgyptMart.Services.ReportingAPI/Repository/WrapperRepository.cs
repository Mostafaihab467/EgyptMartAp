using EgyptMart.Services.ReportingAPI.Data;
using EgyptMart.Services.ReportingAPI.IRepository;

namespace EgyptMart.Services.ReportingAPI.Repository
{
    public class WrapperRepository(DBMasterContext context) : IWrapperRepository
    {
        private IAdminDashboardRepository _adminDashboardRepository;

        public IAdminDashboardRepository AdminDashboardRepository
        {
            get
            {
                _adminDashboardRepository ??= new AdminDashboardRepository(context);
                return _adminDashboardRepository;
            }
        }
    }
}

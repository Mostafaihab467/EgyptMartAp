using EgyptMart.Services.ReportingAPI.IRepository;

namespace EgyptMart.Services.ReportingAPI.Repository
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
     public    ISupplierDashBoardrpository _supplierDashBoardrpository;

        public RepositoryWrapper()
        {
        }

        public RepositoryWrapper(ISupplierDashBoardrpository supplierDashBoardrpository)
        {

            _supplierDashBoardrpository = supplierDashBoardrpository;
        }

        public ISupplierDashBoardrpository supplierDashBoardrpository => _supplierDashBoardrpository;
    }
}

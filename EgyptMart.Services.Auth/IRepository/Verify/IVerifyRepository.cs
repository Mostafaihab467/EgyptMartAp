using EgyptMart.Services.Auth.Models;

namespace EgyptMart.Services.Auth.IRepository
{
    public interface IVerifyRepository
    {
        public Task<int> VerifySupplierRegister(long userID, long verifiedBy, byte status);
        public Task<int> VerifyCustomerRegister(long userID, long verifiedBy);
        public Task<List<PendingVerifySupplierModel>> PendingVerifySupplier();
        public Task<List<PendingVerifyCustomerModel>> PendingVerifyCustomer();
    }
}

using EgyptMart.Services.Auth.DTO;

namespace EgyptMart.Services.Auth.IRepository
{
    public interface IRegisterRepository
    {
        public Task<int> RegisterSupplier(RegisterSupplierDTO dto);
        public Task<int> RegisterCustomer(RegisterDTO dto);
    }
}

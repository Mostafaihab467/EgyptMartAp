using EgyptMart.Services.Auth.DTO;
using EgyptMart.Services.Auth.Models;

namespace EgyptMart.Services.Auth.IRepository
{
    public interface IUsersRepository
    {
        public Task<List<UserModel>> GetListByType(byte TypeID, int PageNumber = 1, int SizePerPage = 50);
        public Task<List<UserModel>> GetUserById(long UserID);
        public Task<int> StoreCode(string UserName, string Code);
        public Task<int> BlockOrUnBlock(long UserID, bool Active = false);
        public Task<int> SetFirstLogin(long UserID, bool FirstLogin = true);
        public Task<List<decimal>> CreateUser(CreateUserDTO dto);
        public Task<List<UserTypesCountModel>> GetWithCount();
        public Task<List<UserTypeModel>> GetSomeTypes();
    }
}

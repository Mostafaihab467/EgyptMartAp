using EgyptMart.Services.Auth.DTO;
using EgyptMart.Services.Auth.Models;

namespace EgyptMart.Services.Auth.IRepository
{
    public interface IAccountsRepository
    {
        public Task<List<LoginResponseModel>> Login(LoginDTO dto);
        public Task<List<byte>> CheckExistEmail(string username);
        public Task<List<FindExistUserModel>> FindExistUser(string? username = null, long? userID = 0);
        public Task<List<LoginResponseModel>> CheckPassword(long userID, string password);
        public Task<int> IncreaseResetFailLoginCounter(long userID, bool reset = false);
        //public Task<List<byte>> CheckExistEmail(string username);
    }
}

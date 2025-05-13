using EgyptMart.Services.Auth.Models;

namespace EgyptMart.Services.Auth.IRepository
{
    public interface IAuthRepository
    {
        public Task<List<RefreshTokenModel>> GetRefreshToken(long userId, string refreshToken);
        public Task<int> StoreRefreshToken(long userId, string refreshToken);
        public Task<int> SaveIpAddress(long userID, string ipAddress);
        public Task<List<string>> GetIpAddress(long userID);
    }
}

using EgyptMart.Services.Auth.Models;

namespace EgyptMart.Services.Auth.IProviderServices
{
    public interface IJWTTokenService
    {

        public string GenerateJWT(string username, string userId, string role, string isVerified);

        public Task<AuthTokenModel> GenerateTokens(string username, string userId, string role, string isVerified);

        public Task<string> RefreshToken(string expiredJwtToken, string refreshToken);


        //public Task<AnomynousTokenModel> AnonymousLogin();

    }
}

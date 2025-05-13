using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using EgyptMart.Services.Auth.Classes;
using EgyptMart.Services.Auth.Data;
using EgyptMart.Services.Auth.IProviderServices;
using EgyptMart.Services.Auth.IRepository;
using EgyptMart.Services.Auth.Models;
using Microsoft.IdentityModel.Tokens;

namespace EgyptMart.Services.Auth.Services
{
    public class JWTTokenService : IJWTTokenService
    {
        private readonly string _secretKey;
        private readonly string _issuer;
        private readonly string _audience;
        //private readonly string _AnomynoussecretKey;
        private readonly int _expirationMinutes;
        private readonly DBMasterContext _context;
        private readonly IAuthRepository _authRepository;
        private readonly IHttpContextAccessor _httpContext;

        public JWTTokenService(IConfiguration configuration,
                                IHttpContextAccessor httpContextAccessor,
                                DBMasterContext context,
                                IAuthRepository authRepository)
        {
            // Securely retrieve the secret key (e.g., from appsettings.json or environment variables)
            _context = context;
            _authRepository = authRepository;

            var jwtSettings = configuration.GetSection("JwtSettings");

            _secretKey = KeyStores.JWT_SECRET_KEY ?? throw new ArgumentNullException("SecretKey is missing in JwtSettings");
            _issuer = KeyStores.JWT_Issuer ?? throw new ArgumentNullException("Issuer is missing in JwtSettings");

            //_AnomynoussecretKey = jwtSettings.GetValue<string>("AnomynousSecretKey");

            _audience = KeyStores.JWT_Audience ?? throw new ArgumentNullException("Audience is missing in JwtSettings");
            _expirationMinutes = KeyStores.JWT_ExpirationMinutes;

            _httpContext = httpContextAccessor;

        }

        /// <summary>
        /// Generates a JWT token with specified claims.
        /// </summary>
        public string GenerateJWT(string username, string userId, string role, string isVerified)
        {
            var claims = new[]
            {
                    new Claim(ClaimTypes.Name, username),
                    new Claim(ClaimTypes.NameIdentifier, userId),
                    new Claim(ClaimTypes.Role, role),
                    new Claim("IPAddress" , GetClientIpAddress()),
                    new Claim("IsVerified" , isVerified )
                    //new Claim("Permmisions", "Add_Product","True"),
                //    new Claim("Permmisions", "Edit_Product","True"),
                  //  new Claim(ClaimTypes.Role, "Customer")
                };

            return JwtSettingHandler(claims);
        }

        /// <summary>
        /// Generates both JWT and Refresh tokens.
        /// </summary>
        public async Task<AuthTokenModel> GenerateTokens(string username, string userId, string role, string isVerified)
        {
            try
            {
                var jwtToken = GenerateJWT(username, userId, role, isVerified);
                var refreshToken = Convert.ToBase64String(Guid.NewGuid().ToByteArray());

                await _authRepository.StoreRefreshToken(long.Parse(userId), refreshToken);

                return new AuthTokenModel { Jwt = jwtToken, RefreshToken = refreshToken };
            }
            catch (Exception) { throw; }
        }

        /// <summary>
        /// Refreshes a JWT token using a valid refresh token.
        /// </summary>
        public async Task<string> RefreshToken(string expiredJwtToken, string refreshToken)
        {



            try
            {
                List<Claim> claims = ExtractClaimsFromExpiredToken(expiredJwtToken);
                var UserId = claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value;
                var OldUserIpAddress = claims.FirstOrDefault(x => x.Type == "IPAddress").Value;

                if (UserId == null || OldUserIpAddress == null) { throw new SecurityTokenException("No Valid Token"); }

                // Check if the user has a stored refresh token

                var storedToken = await _authRepository.GetRefreshToken(long.Parse(UserId), refreshToken);
                if (storedToken.Count < 1 || storedToken.FirstOrDefault() == null) { throw new SecurityTokenException($"Refresh token not found for this user."); }

                // Validate the refresh token and expiration
                if (storedToken.FirstOrDefault().RefreshToken != refreshToken ||
                    storedToken.FirstOrDefault().RefreshTokenExpireDate < DateTime.Now)
                    throw new SecurityTokenException("Invalid or expired refresh token.");

                // Validate IP Address compare
                if (!GetClientIpAddress().Equals(OldUserIpAddress))
                    throw new SecurityTokenException("Not same users");



                // Generate a new JWT token with the same claims
                return JwtSettingHandler(claims);
            }
            catch (Exception ex)
            {
                throw new SecurityTokenException(ex.Message, ex);
            }

        }

        /// <summary>
        /// Extracts claims from an expired token without validating its expiration.
        /// </summary>
        public List<Claim> ExtractClaimsFromExpiredToken(string token)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();

                // Define validation parameters (lifetime is ignored to allow expired tokens)
                var validationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = false, // Allow expired tokens
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_secretKey)),
                    ValidIssuer = _issuer,
                    ValidAudience = _audience,
                };

                // Validate the token and extract claims
                var principal = tokenHandler.ValidateToken(token, validationParameters, out SecurityToken validatedToken);

                // Ensure the token is a JWT token
                if (validatedToken is not JwtSecurityToken jwtToken)
                    throw new SecurityTokenException("Invalid token format.");

                // Convert claims to a list
                return principal.Claims.ToList();
            }
            catch (Exception ex)
            {
                // Wrap exceptions for better debugging
                throw new SecurityTokenException("Failed to extract claims from the token.", ex);
            }
        }




        private string JwtSettingHandler(IEnumerable<Claim> claims)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_secretKey));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _issuer,
                audience: _audience,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(_expirationMinutes),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        //public async Task<AnomynousTokenModel> AnonymousLogin()
        //{
        //    var clientId = Guid.NewGuid().ToString();
        //    //later we will get the ip address from the request
        //    var ipAddr = GetClientIpAddress();
        //    var claims = new[]
        //        {

        //            new Claim(ClaimTypes.Role, "AmomynousUser"),
        //            new Claim("ClientId",  clientId),
        //            new Claim("ipaddr",  ipAddr),

        //        };

        //    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_AnomynoussecretKey));
        //    var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        //    var token = new JwtSecurityToken(
        //        issuer: _issuer,
        //        audience: _audience,
        //        claims: claims,
        //        expires: DateTime.UtcNow.AddMinutes(_expirationMinutes),
        //        signingCredentials: credentials
        //    );

        //    var Anomynustoken = new JwtSecurityTokenHandler().WriteToken(token);

        //    return new AnomynousTokenModel { jwt = Anomynustoken };

        //}


        private string GetClientIpAddress()
        {
            if (_httpContext.HttpContext == null)
            {
                return "Unknown";
            }

            // Check for headers set by proxies (if behind a load balancer or reverse proxy)
            string ip = _httpContext.HttpContext.Request.Headers["X-Forwarded-For"].FirstOrDefault();

            if (string.IsNullOrEmpty(ip))
            {
                ip = _httpContext.HttpContext.Connection.RemoteIpAddress?.ToString();
            }

            return string.IsNullOrEmpty(ip) ? "Unknown" : ip;
        }
    }
}

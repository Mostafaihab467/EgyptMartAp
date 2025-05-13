namespace EgyptMart.Services.Auth.Models
{
    public class AuthTokenModel
    {
        public string Jwt { get; set; }
        public string RefreshToken { get; set; }
    }
}

namespace EgyptMart.Services.Auth.Models
{
    public class RefreshTokenModel
    {

        public string RefreshToken { get; set; }

        public DateTime RefreshTokenExpireDate { get; set; }
    }
}

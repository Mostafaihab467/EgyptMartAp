namespace EgyptMart.Services.Auth.Models
{
    public class LoginResponseModel
    {
        public long UserID { get; set; }
        public string DisplayName { get; set; } = string.Empty;
        public byte UserTypeID { get; set; }
        public string ProfileImage { get; set; } = string.Empty;
        public bool IsVerfied { get; set; }
        public bool IsActive { get; set; }
        public string UserName { get; set; } = string.Empty;
        public bool FirstLogin { get; set; }
        public byte FailLoginCount { get; set; }

        public object GetItem => new
        {
            UserID,
            DisplayName,
            ProfileImage,
            IsVerfied,
            IsActive,
            UserName,
            FirstLogin,
            FailLoginCount
        };
    }
}

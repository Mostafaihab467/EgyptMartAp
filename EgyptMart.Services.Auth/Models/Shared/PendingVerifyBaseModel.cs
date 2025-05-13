namespace EgyptMart.Services.Auth.Models
{
    public class PendingVerifyBaseModel
    {
        public string DisplayName { get; set; }
        public string UserName { get; set; }
        public DateTime RegisterdSince { get; set; }
    }
}

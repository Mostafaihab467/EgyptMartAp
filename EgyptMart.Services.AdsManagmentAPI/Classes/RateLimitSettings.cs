namespace EgyptMart.Services.AdsManagmentAPI.Classes
{

    public class RateLimiterOptions
    {
        public IpRateLimitOptions? Ip { get; set; }
        public GlobalRateLimitOptions? Global { get; set; }

    }
    public class IpRateLimitOptions
    {
        public int PermitRequests { get; set; }
        public int InMinutes { get; set; }
        public int Queue { get; set; }
    }

    public class GlobalRateLimitOptions
    {
        public int PermitRequests { get; set; }
        public int InMinutes { get; set; }
        public int Queue { get; set; }
    }


}

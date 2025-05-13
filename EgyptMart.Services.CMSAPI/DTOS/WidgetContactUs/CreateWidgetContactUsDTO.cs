namespace EgyptMart.Services.CMSAPI.DTOS
{
    public class CreateWidgetContactUsDTO
    {
        public string? EmailAddress { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Address { get; set; }
        public string? Website { get; set; }
        public decimal? Longitude { get; set; }
        public decimal? Latitude { get; set; }
    }
}

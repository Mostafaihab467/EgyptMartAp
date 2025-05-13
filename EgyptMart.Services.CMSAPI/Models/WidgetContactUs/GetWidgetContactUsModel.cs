namespace EgyptMart.Services.CMSAPI.Models
{
    public class GetWidgetContactUsModel
    {
        public byte ContactUsID { get; set; } // TINYINT maps to byte in C#

        public string? EmailAddress { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Address { get; set; }
        public string? Website { get; set; }

        public decimal? Longitude { get; set; } // DECIMAL(9,6)
        public decimal? Latitude { get; set; }

        public byte LangID { get; set; }
        public byte BaseID { get; set; }


        public DateTime UpdatedAt { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}

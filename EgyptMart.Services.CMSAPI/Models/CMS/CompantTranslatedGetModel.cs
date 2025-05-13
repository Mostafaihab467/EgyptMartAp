namespace EgyptMart.Services.CMSAPI.Models
{
    public class CompantTranslatedGetModel
    {

        public long? LinkID { get; set; }

        public long UserID { get; set; }

        public byte LangID { get; set; }

        public short? BusinessTypeID { get; set; }

        public string? CompanyTitle { get; set; }

        public string? BusinessRange { get; set; }
        public string? BusinessProducts { get; set; }

        public string? RegisterdCapital { get; set; }

        public string? NumberOfEmployee { get; set; }
        public string? ProfileImage { get; set; }

        public string? TaxRegistrationNo { get; set; }

        public string? CompanyBIO { get; set; }

        public string? TradeCapacity { get; set; }
    }
}

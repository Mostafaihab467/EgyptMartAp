using System.ComponentModel.DataAnnotations;

namespace EgyptMart.Services.CMSAPI.DTOS.CMS
{
    public class PreUsersExtSuppliersExtTranslationDto
    {
        [Required]
        public long LinkID { get; set; }
        [Required]
        public byte LangID { get; set; }
        [Required]
        [StringLength(1000, MinimumLength = 1)]
        public string CompanyTitle { get; set; }
        [Required]
        public string BusinessRange { get; set; }
        [Required]
        public string BusinessProducts { get; set; }
        [Required]
        public string RegisterdCapital { get; set; }
        [Required]
        public string NumberOfEmployee { get; set; }
        [Required]
        public string TaxRegistrationNo { get; set; }
        [Required]
        public string CompanyBIO { get; set; }
        [Required]
        public string TradeCapacity { get; set; }
    }
}

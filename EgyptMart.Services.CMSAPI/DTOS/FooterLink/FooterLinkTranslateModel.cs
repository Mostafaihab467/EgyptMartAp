using System.ComponentModel.DataAnnotations;

namespace EgyptMart.Services.CMSAPI.DTOS.FooterLink
{
    public class FooterLinkTranslateDto
    {
        [Required]
        [StringLength(10000,MinimumLength =1 ,ErrorMessage = "FooterItemTitle Cannot Be Empty String")]
        public string FooterItemTitle { get; set; }  // Translated Title
        [Required]
    
        public long BasID { get; set; }  // Reference to original FooterItemID
        [Required]
        public byte LangID { get; set; }  // Language ID
    }
}

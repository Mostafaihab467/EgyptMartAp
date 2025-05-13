using System.ComponentModel.DataAnnotations;

namespace EgyptMart.Services.CMSAPI.DTOS.FooterLink
{
    public class FooterLinkStatusDto
    {
        [Required]
        public int FooterItemID { get; set; }
        [Required]
        public bool IsActive { get; set; }
    }
}

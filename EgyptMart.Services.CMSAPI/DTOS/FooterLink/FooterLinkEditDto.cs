using System.ComponentModel.DataAnnotations;

namespace EgyptMart.Services.CMSAPI.DTOS.FooterLink
{
    public class FooterLinkEditDto
    {
        [Required]
        public int FooterItemID { get; set; }
        [Required]
        public string FooterItemTitle { get; set; }
        [Required]
        public string TargetUrl { get; set; }
        [Required]
        [Range(0,short.MaxValue)]
        public short DisplayOrder { get; set; }
        [Required]     
        public byte ColumnIndex { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace EgyptMart.Services.CMSAPI.DTOS.FooterLink
{
    public class WidgetsFooterLinksCreateRequestDto
    {
        /// <summary>
        /// Title of the footer item.
        /// </summary>
        [Required]
        [StringLength(10000, MinimumLength = 1, ErrorMessage = "FooterItemTitle Cannot Be Empty String")]
        public string FooterItemTitle { get; set; }

        /// <summary>
        /// The target URL for the footer item.
        /// </summary>
        [Required]
        public string TargetUrl { get; set; }

        /// <summary>
        /// The display order of the footer item.
        /// </summary>
        [Required]
        [Range(0,short.MaxValue)]
        public short DisplayOrder { get; set; }

        /// <summary>
        /// The column index where the footer item will appear.
        /// </summary>
        [Required]
        public byte ColumnIndex { get; set; }
    }
}

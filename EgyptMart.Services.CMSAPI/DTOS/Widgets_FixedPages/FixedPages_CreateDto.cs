using System.ComponentModel.DataAnnotations;

namespace EgyptMart.Services.CMSAPI.DTOS.Widgets_FixedPages
{
    public class FixedPages_CreateDto
    {
        [Required]
        public string PageTitle { get; set; }
        [Required]
        public string PageBody { get; set; }
    }
}

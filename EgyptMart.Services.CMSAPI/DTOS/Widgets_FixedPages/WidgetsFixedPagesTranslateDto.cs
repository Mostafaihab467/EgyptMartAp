using System.ComponentModel.DataAnnotations;

namespace EgyptMart.Services.CMSAPI.DTOS.Widgets_FixedPages
{
    public class WidgetsFixedPagesTranslateDto
    {
        [Required]
        public int BaseID { get; set; }
        [Required]
        public byte LangID { get; set; }
        [Required]
        public string PageTitle { get; set; }
        [Required]
        public string PageBody { get; set; }
    }
}

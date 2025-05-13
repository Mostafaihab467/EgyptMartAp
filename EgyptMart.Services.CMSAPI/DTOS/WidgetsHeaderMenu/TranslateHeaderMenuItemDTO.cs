using System.ComponentModel.DataAnnotations;

namespace EgyptMart.Services.CMSAPI.DTOS.WidgetsHeaderMenu
{
    public class TranslateHeaderMenuItemDTO
    {
        [Required]
        public int BasID { get; set; }
        [Required]
        public string MenuItemTitle { get; set; }
        [Required]
        public short LangID { get; set; }
      
    }
}

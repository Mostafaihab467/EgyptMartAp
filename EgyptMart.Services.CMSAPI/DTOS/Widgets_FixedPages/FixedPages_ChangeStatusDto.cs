using System.ComponentModel.DataAnnotations;

namespace EgyptMart.Services.CMSAPI.DTOS.Widgets_FixedPages
{
    public class FixedPages_ChangeStatusDto
    {
        [Required]
        public int PageID { get; set; }
        [Required]
        public bool IsActive { get; set; }
    }
}

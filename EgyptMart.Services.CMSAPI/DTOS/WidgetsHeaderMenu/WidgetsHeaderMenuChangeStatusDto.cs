using System.ComponentModel.DataAnnotations;

namespace EgyptMart.Services.CMSAPI.DTOS.WidgetsHeaderMenu
{
    public class WidgetsHeaderMenuChangeStatusDto
    {
        [Required]
        public int MenuItemID { get; set; } // The ID of the menu item to update

        [Required(ErrorMessage = "Must be boolean (true or false).")]
        public bool NewStatus { get; set; } // The new status (active/inactive)
    }
}

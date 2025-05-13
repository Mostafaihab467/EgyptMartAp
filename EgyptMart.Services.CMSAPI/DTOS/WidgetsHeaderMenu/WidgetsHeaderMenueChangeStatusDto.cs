using System.ComponentModel.DataAnnotations;

namespace EgyptMart.Services.CMSAPI.Models
{
    public class WidgetsHeaderMenueChangeStatusDto
    {
        [Required]
        public short MenuItemID { get; set; } // The ID of the link to update
        [Required(ErrorMessage = "Must Be boolean true or false")]
        public bool NewStatus { get; set; } // The new status (active/inactive)
    }
}

using Microsoft.AspNetCore.Mvc.Infrastructure;
using System.ComponentModel.DataAnnotations;

namespace EgyptMart.Services.CMSAPI.DTOS.WidgetsHeaderMenu
{  
    public class WidgetsHeaderMenuEditDto 
    {
        [Required]
        public int MenuItemID { get; set; } // Identifier for the menu item to edit
        [Required]
        public string MenuItemTitle { get; set; } // New title for the menu item
        [Required]
        public short DisplayOrder { get; set; } // Updated display order
        [Required]
        public string TargetUrl { get; set; } // Updated target URL
        }
    

}

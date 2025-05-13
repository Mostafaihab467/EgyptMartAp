using System.ComponentModel.DataAnnotations;

namespace EgyptMart.Services.CMSAPI.Models.WidgetHeaderMenue
{
    public class WidgetsHeaderMenuModel
    {
        [Required] // Mandatory field
        public int MenuItemID { get; set; } // int, not nullable

        [StringLength(50)] // Maximum length matches database constraint
        public string MenuItemTitle { get; set; } // varchar(50), nullable

        public byte? LangID { get; set; } // tinyint, nullable

        public int? BasID { get; set; } // int, nullable

        public int? ParentID { get; set; } // int, nullable

        [StringLength(int.MaxValue)] // No fixed max length as per nvarchar(-1)
        public string TargetUrl { get; set; } // nvarchar(-1), nullable

        public bool? IsActive { get; set; } // bit, nullable

        public short? DisplayOrder { get; set; } // smallint, nullable
    }
}

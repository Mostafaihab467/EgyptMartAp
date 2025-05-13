using System.ComponentModel.DataAnnotations;

namespace EgyptMart.Services.CMSAPI.DTOS.WidgetsHeaderMenu
{
    public class WidgetsHeaderMenuGetChildDtos
    {
        [Required]
        public byte RepType { get; set; } // tinyint -> byte
        [Required]
        public short LangID { get; set; } // smallint -> short
        [Required]
        public long ParentID { get; set; } // bigint -> long
    }
}

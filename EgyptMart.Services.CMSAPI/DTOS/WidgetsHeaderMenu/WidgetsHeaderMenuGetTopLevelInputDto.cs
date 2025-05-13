using System.ComponentModel.DataAnnotations;

namespace EgyptMart.Services.CMSAPI.Models
{
    public class WidgetsHeaderMenuGetTopLevelInputDto
    {
        [Required]
        public byte RepType { get; set; }  // Represents the RepType (TinyInt)
        [Required]
        public short LangID { get; set; }  // Represents the LangID (SmallInt)
    }
}

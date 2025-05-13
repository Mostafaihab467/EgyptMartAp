using System.ComponentModel.DataAnnotations;

namespace EgyptMart.Services.CMSAPI.DTOS
{
    public class CreateWidgetFAQDTO
    {
        [Required(ErrorMessage = "QTitle is required.")]
        public string QTitle { get; set; }  // nvarchar(max) in SQL

        [Required(ErrorMessage = "QAnswer is required.")]
        public string QAnswer { get; set; } // nvarchar(max) in SQL

        [Required(ErrorMessage = "DisplayOrder is required.")]
        public short DisplayOrder { get; set; }  // smallint in SQL
    }
}

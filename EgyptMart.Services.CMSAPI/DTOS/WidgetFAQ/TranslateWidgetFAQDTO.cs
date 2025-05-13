using System.ComponentModel.DataAnnotations;

namespace EgyptMart.Services.CMSAPI.DTOS
{
    public class TranslateWidgetFAQDTO
    {
        [Required]
        public int BaseID { get; set; }  // int in SQL
        [Required]
        public byte LangID { get; set; }  // tinyint in SQL
        [Required]
        public string QTitle { get; set; }  // nvarchar(max) in SQL
        [Required]
        public string QAnswer { get; set; } // nvarchar(max) in SQL


    }
}

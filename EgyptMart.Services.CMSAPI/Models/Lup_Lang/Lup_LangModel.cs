using System.ComponentModel.DataAnnotations;

namespace EgyptMart.Services.CMSAPI.Models.Lup_Lang
{
    public class Lup_LangModel
    {
        [Required]
        public byte LangID { get; set; }  // Tinyint corresponds to byte in C#

        [Required]

        public string LangTitle { get; set; }  // nvarchar(50) corresponds to string

        [Required]

        public string Direction { get; set; }  // varchar(50) corresponds to string
    }
}

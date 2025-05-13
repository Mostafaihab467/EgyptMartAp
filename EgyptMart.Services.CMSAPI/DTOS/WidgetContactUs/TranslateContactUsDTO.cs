using System.ComponentModel.DataAnnotations;

namespace EgyptMart.Services.CMSAPI.DTOS
{
    public class TranslateContactUsDTO
    {
        [Required]
        [Range(1, 255)]
        public byte BaseID { get; set; }
        [Required]
        [MaxLength(255)]
        public string Address { get; set; }
        [Required]
        [Range(1, 255)]
        public byte LangID { get; set; }
    }
}

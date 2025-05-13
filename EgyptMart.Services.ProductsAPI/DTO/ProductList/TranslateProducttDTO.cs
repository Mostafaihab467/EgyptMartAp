#nullable disable
using System.ComponentModel.DataAnnotations;

namespace EgyptMart.Services.ProductsAPI.DTO
{
    public class TranslateProducttDTO
    {
       
        [Required(ErrorMessage = "BaseProductID is required")]
        public long ProductsID { get; set; } = 0;

        [Required(ErrorMessage = "LangID is required")]
        public byte LangID { get; set; }

        [Required(ErrorMessage = "ProductTitle is required")]
        public string ProductTitle { get; set; }

        [Required(ErrorMessage = "SEOKey is required")]
        public string SEOKey { get; set; }

        [MaxLength(140, ErrorMessage = "out of scope range")]
        public string ShortDesc { get; set; }

        [MaxLength(2000, ErrorMessage = "out of scope range")]
        public string FullDesc { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace EgyptMart.Services.ProductsAPI.DTO
{
    public class TranslateProductAttributeValueDTO
    {
        [Required]
        public long LinkID { get; set; }
        [Required]
        public string Value { get; set; }
        [Required]
        public byte LangID { get; set; }
    }
}

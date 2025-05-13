#nullable disable
using System.ComponentModel.DataAnnotations;

namespace EgyptMart.Services.ProductsAPI.DTO
{
    public class CreateProductAttributesDTO
    {
        [Required(ErrorMessage = "ProductID is required")]
        [Range(0, long.MaxValue)]

        public long ProductID { get; set; }

        [Required(ErrorMessage = "AttributeID is required")]
        [Range(0, int.MaxValue)]

        public int AttributeID { get; set; }

        [Required(ErrorMessage = "Value is required")]
        [MinLength(1, ErrorMessage = "Value cannot be empty")]
        public string Value { get; set; }

        [Required(ErrorMessage = "LangID is required")]
        [Range(0, int.MaxValue)]

        public byte LangID { get; set; }

        [Required(ErrorMessage = "DisplayOrder is required")]
        [Range(1, int.MaxValue)]

        public short DisplayOrder { get; set; }
    }
}

#nullable disable
using System.ComponentModel.DataAnnotations;

namespace EgyptMart.Services.ProductsAPI.DTO
{
    public class EditProductAttributesDTO
    {
        [Required(ErrorMessage = "LinkID is required")]
        [Range(0, int.MaxValue)]

        public long LinkID { get; set; }

        [Required(ErrorMessage = "Value is required")]
        [StringLength(maximumLength: 10000000, MinimumLength = 1)]
        public string Value { get; set; }

        [Required(ErrorMessage = "DisplayOrder is required")]
        [Range(1, int.MaxValue)]

        public short DisplayOrder { get; set; }
    }
}

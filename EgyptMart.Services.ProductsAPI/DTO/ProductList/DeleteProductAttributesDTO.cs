using System.ComponentModel.DataAnnotations;

namespace EgyptMart.Services.ProductsAPI.DTO
{
    public class DeleteProductAttributesDTO
    {
        [Required(ErrorMessage = "LinkID is required")]
        [Range(0, int.MaxValue)]

        public long LinkID { get; set; }
    }
}

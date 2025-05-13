using System.ComponentModel.DataAnnotations;

namespace EgyptMart.Services.ProductsAPI.DTO
{
    public class ChangeStatusProductDTO
    {
        [Required(ErrorMessage = "ProductID is required")]

        public long ProductsID { get; set; }

        [Required(ErrorMessage = "NewProductStatus is required")]
        [Range(0,1, ErrorMessage = "NewProductStatus must be true or false")]
        public bool NewProductStatus { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace EgyptMart.Services.ProductsAPI.DTO
{
    public class GetProductReviewDTO
    {
        [Required(ErrorMessage = "Product ID is required")]
        public long ProductID { get; set; }

        [Required(ErrorMessage = "RepType is required"), Range(0, 1, ErrorMessage = "Invalid Number")]
        public byte RepType { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace EgyptMart.Services.ProductsAPI.DTO
{
    public class ApproveProductsRatingsDTO
    {
        [Required(ErrorMessage = "RatingID is required")]
        [Range(0, int.MaxValue)]

        public long RatingID { get; set; }

        [Required(ErrorMessage = "ApprovalStatu is required")]
        [Range(0, int.MaxValue)]

        public byte ApprovalStatu { get; set; }

        [Required(ErrorMessage = "ActionBy is required")]
        [Range(0,int.MaxValue)]
        public long ActionBy { get; set; }
    }
}

#nullable disable
using System.ComponentModel.DataAnnotations;

namespace EgyptMart.Services.ProductsAPI.DTO
{
    public class CreateProductsRatingsDTO
    {
        [Required(ErrorMessage = "ProductID is required")]
        [Range(0, int.MaxValue)]

        public long ProductID { get; set; }

        [Required(ErrorMessage = "UserID is required")]
        [Range(0, int.MaxValue)]

        public long UserID { get; set; }

        [Required(ErrorMessage = "RatingScore is required")]
        [Range(0, 5)]

        public byte RatingScore { get; set; }

        [Required(ErrorMessage = "RatingTitle is required")]
        public string RatingTitle { get; set; }


        [Required(ErrorMessage = "LinkedPO is required")]
        [Range(0, int.MaxValue)]

        public long LinkedPO { get; set; }

        [Required(ErrorMessage = "RatingDesc is required")]
        public string RatingDesc { get; set; }
    }
}

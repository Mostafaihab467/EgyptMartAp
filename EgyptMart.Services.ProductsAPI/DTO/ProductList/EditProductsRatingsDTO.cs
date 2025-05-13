#nullable disable
using System.ComponentModel.DataAnnotations;

namespace EgyptMart.Services.ProductsAPI.DTO
{
    public class EditProductsRatingsDTO
    {
        [Required(ErrorMessage = "RatingID is required")]
        [Range(0, long.MaxValue)]
        
        public long RatingID { get; set; }

        [Required(ErrorMessage = "RatingScore is required")]
        [Range(0, 5)]

        public byte RatingScore { get; set; }

        [Required(ErrorMessage = "RatingTitle is required")]
        public string RatingTitle { get; set; }

        [Required(ErrorMessage = "RatingDesc is required")]
        public string RatingDesc { get; set; }
    }
}

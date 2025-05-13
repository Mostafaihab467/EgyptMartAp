#nullable disable
using System.ComponentModel.DataAnnotations;

namespace EgyptMart.Services.ProductsAPI.DTOs
{
    public class EditeProductImagesDTO
    {
        [Required(ErrorMessage = "ImageID is required")]
        [Range(0, long.MaxValue)]

        public long ImageID { get; set; }

        [Required(ErrorMessage = "ImageURL is required")]
        public string ImageURL { get; set; }

        [Required(ErrorMessage = "IsThumbMain is required")]
        [Range(0, 1, ErrorMessage = "IsThumbMain must be true or false")]
        public bool IsThumbMain { get; set; }

        [Required(ErrorMessage = "IsMain is required")]
        [Range(0, 1, ErrorMessage = "IsMain must be true or false")]
        public bool IsMain { get; set; }

        public byte[] fileBytes { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        public Int32 ProductID { get; set; }
    }
}

#nullable disable
using System.ComponentModel.DataAnnotations;

namespace EgyptMart.Services.ProductsAPI.DTO
{
    public class UploadProductImageDTO
    {
        [Required(ErrorMessage = "ProductID is required")]
        public long ProductID { get; set; }

        [Required(ErrorMessage = "ImageURL is required"), MaxLength(250, ErrorMessage = "Max Length less than 250")]
        public string ImageURL { get; set; }

        [Required(ErrorMessage = "IsThumbMain is required")]
        [Range(0, 1, ErrorMessage = "IsThumbMain must be true or false")]
        public bool IsThumbMain { get; set; }

        [Required(ErrorMessage = "IsMain is required")]
        [Range(0, 1, ErrorMessage = "IsMain must be true or false")]
        public bool IsMain { get; set; }

        public byte[] fileBytes { get; set; }
    }
}

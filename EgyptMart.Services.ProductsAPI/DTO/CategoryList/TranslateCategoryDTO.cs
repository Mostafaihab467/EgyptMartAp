using System.ComponentModel.DataAnnotations;

namespace EgyptMart.Services.ProductsAPI.DTO
{
    public class TranslateCategoryDTO
    {
        [Required]
        public int CategoryID { get; set; }
        [Required]
        [MinLength(1, ErrorMessage = "Cannot Be Empty")]
        [MaxLength(200)]
        public string CategoryTitle { get; set; }
        [Required]
        [Range(0,byte.MaxValue)]
        public byte LangID { get; set; }
    }
}

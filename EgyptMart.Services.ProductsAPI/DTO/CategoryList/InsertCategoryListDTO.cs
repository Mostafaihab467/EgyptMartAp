#nullable disable
using System.ComponentModel.DataAnnotations;

namespace EgyptMart.Services.ProductsAPI.DTO
{
    public class InsertCategoryListDTO
    {
        [Required]
        [MinLength(1, ErrorMessage = "Cannot Be Empty")]
        [MaxLength(200)]
        public string CategoryTitle { get; set; }

        [Required]
        [Range(0, int.MaxValue)]

        public int ParentID { get; set; } = 0;
        [Required]
        [Range(int.MinValue, int.MaxValue)]

        public int LangID { get; set; } = 0;
        [Required]
        [Range(1, int.MaxValue)]
        public int DisplayOrder { get; set; } = 0;
        [Required]
        public string CategoryImageURL { get; set; } = "";
    }
}

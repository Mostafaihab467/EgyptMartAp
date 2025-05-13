using System.ComponentModel.DataAnnotations;

namespace EgyptMart.Services.ProductsAPI.DTO.CategoryList
{

    public class UpdateCategoryDto
    {
        [Required]
        public int CategoryID { get; set; }
        [Required]
        [MinLength(1, ErrorMessage = "Cannot Be Empty")]
        [MaxLength(200)]

        public string? CategoryTitle { get; set; }
        [Required]
        [Range(0,int.MaxValue)]
        public int? ParentID { get; set; }
        [Required]
        [Range(0,1,ErrorMessage = "Cannot only True Or False or 0 OR 1 ")]
        public bool? IsActive { get; set; } = null;
    }
}


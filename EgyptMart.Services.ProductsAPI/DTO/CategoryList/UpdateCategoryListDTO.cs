#nullable disable
using System.ComponentModel.DataAnnotations;

namespace EgyptMart.Services.ProductsAPI.DTO
{
    public class ChangeStatusDTO
    {
        [Required]
        public int CategoryID { get; set; }
        [Required]
        [StringLength(maximumLength: 1000, MinimumLength =1 )]
        public string CategoryTitle { get; set; }
        [Required]
        [Range(0,int.MaxValue,ErrorMessage = "DisplayOrder Cannot Be Negative")]
        public short DisplayOrder { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace EgyptMart.Services.ProductsAPI.DTO
{
    public class SetActiveDto
    {

        [Required]
        public int CategoryID { get; set; }
        [Required]
        public bool isActive { get; set; }
    }
}

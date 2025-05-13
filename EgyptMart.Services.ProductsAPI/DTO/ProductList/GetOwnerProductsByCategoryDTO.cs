using System.ComponentModel.DataAnnotations;

namespace EgyptMart.Services.ProductsAPI.DTO
{
    public class GetOwnerProductsByCategoryDTO
    {
        [Required(ErrorMessage = "OwnerID is required")]
        public long OwnerID { get; set; }

        [Required(ErrorMessage = "CategoryID is required")]
  
        public int CategoryID { get; set; }

        [Required(ErrorMessage = "RepType is required"), Range(0, 1, ErrorMessage = "Invalid Number")]

        public byte RepType { get; set; }
    }
}

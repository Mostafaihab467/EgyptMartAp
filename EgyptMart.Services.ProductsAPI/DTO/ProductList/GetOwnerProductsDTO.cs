using System.ComponentModel.DataAnnotations;

namespace EgyptMart.Services.ProductsAPI.DTO
{
    public class GetOwnerProductsDTO
    {
        [Required(ErrorMessage = "Owner ID is required")]
        public long OwnerID { get; set; }

        [Required(ErrorMessage = "RepType is required"), Range(0, 2, ErrorMessage = "Invalid Number")]

        public byte RepType { get; set; }
    }
}

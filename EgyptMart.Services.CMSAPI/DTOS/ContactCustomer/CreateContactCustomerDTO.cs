using System.ComponentModel.DataAnnotations;
using EgyptMart.Services.CMSAPI.Validations;

namespace EgyptMart.Services.CMSAPI.DTOS
{
    public class CreateContactCustomerDTO
    {
        [Required(ErrorMessage = "CustomerID is required.")]
        [MinValidator(1)]
        public long CustomerID { get; set; }

        [Required(ErrorMessage = "SupplierID is required.")]
        [MinValidator(1)]
        public long SupplierID { get; set; }

        [Required(ErrorMessage = "Title is required.")]
        [MaxLength(255, ErrorMessage = "Title cannot exceed 255 characters.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Body is required.")]
        public string Body { get; set; }
    }
}

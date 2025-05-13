using System.ComponentModel.DataAnnotations;
using EgyptMart.Services.CMSAPI.Validations;

namespace EgyptMart.Services.CMSAPI.DTOS
{
    public class ReplyContactCustomerDTO
    {
        [Required(ErrorMessage = "ContactID is required.")]
        [MinValidator(1)]
        public long ContactID { get; set; }
        [Required]
        [MinValidator(1)]
        public long MessageID { get; set; }
        [Required(ErrorMessage = "SupplierID is required.")]
        [MinValidator(1)]
        public long SupplierID { get; set; }

        [Required(ErrorMessage = "ReplyBody is required.")]
        public string ReplyBody { get; set; } = string.Empty;
    }
}

using System.ComponentModel.DataAnnotations;
using EgyptMart.Services.CMSAPI.Validations;

namespace EgyptMart.Services.CMSAPI.DTOS
{
    public class AddContactCustomerMessageDTO
    {
        [Required(ErrorMessage = "ContactID is required.")]
        public long ContactID { get; set; }

        [Required(ErrorMessage = "CustomerID is required.")]
        [MinValidator(1)]
        public long CustomerID { get; set; }

        [Required(ErrorMessage = "Body is required.")]
        public string Body { get; set; }

    }
}

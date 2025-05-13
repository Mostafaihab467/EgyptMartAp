using System.ComponentModel.DataAnnotations;

namespace EgyptMart.Services.Auth.DTO
{
    public class RegisterSupplierDTO : RegisterDTO
    {

        [Required(ErrorMessage = "Required")]
        public string TaxRegistrationNo { get; set; }
    }
}

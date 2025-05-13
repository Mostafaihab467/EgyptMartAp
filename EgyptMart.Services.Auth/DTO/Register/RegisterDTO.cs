using System.ComponentModel.DataAnnotations;
using EgyptMart.Services.Auth.Validations;

namespace EgyptMart.Services.Auth.DTO
{
    public class RegisterDTO
    {


        [Required(ErrorMessage = "Required")]
        public string CompanyName { get; set; }


        [Required(ErrorMessage = "Required")]
        [EmailAddress]
        [MaxLength(100)]
        public string UserName { get; set; }


        [Required(ErrorMessage = "Required")]
        [MaxLength(50)]
        public string Password { get; set; }


        [Required(ErrorMessage = "Required")]
        [MinValidator(0)]
        public short BusinessTypeID { get; set; }

        [Required(ErrorMessage = "Required")]
        [MinValidator(0)]
        public long LocationID { get; set; }


    }
}

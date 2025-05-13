using System.ComponentModel.DataAnnotations;
using EgyptMart.Services.Auth.Validations;

namespace EgyptMart.Services.Auth.DTO
{
    public class ChangePasswordDTO
    {
        [Required]
        [MaxLength(50)]
        [IsMatchValidator(UnEqual = true, PropName = "OldPassword")]
        public string NewPassword { get; set; }
        [Required]
        [IsMatchValidator]
        public string ConfirmPassword { get; set; }

    }
}

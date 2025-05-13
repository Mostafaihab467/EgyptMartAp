using System.ComponentModel.DataAnnotations;

namespace EgyptMart.Services.Auth.DTO
{
    public class ReplaceOldPasswordDTO : ChangePasswordDTO
    {
        [Required]
        [MaxLength(50)]

        public string OldPassword { get; set; }
    }
}

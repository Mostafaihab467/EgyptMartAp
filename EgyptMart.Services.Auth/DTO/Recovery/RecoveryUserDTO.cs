using System.ComponentModel.DataAnnotations;

namespace EgyptMart.Services.Auth.DTO
{
    public class RecoveryUserDTO
    {
        [Required(ErrorMessage = "Required")]
        [MaxLength(100)]
        public string UserName { get; set; }
    }
}

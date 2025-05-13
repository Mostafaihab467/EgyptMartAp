using System.ComponentModel.DataAnnotations;

namespace EgyptMart.Services.Auth.DTO
{
    public class LoginDTO
    {
        [Required(ErrorMessage = "Required")]
        [MaxLength(100)]
        public string UserName { get; set; }


        [Required(ErrorMessage = "Required")]
        [MaxLength(50)]
        public string Password { get; set; }


        [Required(ErrorMessage = "Required")]
        [Range(1, 3)]
        public byte PortalType { get; set; }


    }
}

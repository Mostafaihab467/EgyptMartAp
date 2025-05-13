using System.ComponentModel.DataAnnotations;

namespace EgyptMart.Services.Auth.DTO
{
    public class CreateUserDTO
    {
        [Required(ErrorMessage = "Display Name is required.")]
        public string DisplayName { get; set; }

        [Required(ErrorMessage = "User Name is required.")]
        [StringLength(100, ErrorMessage = "User Name cannot be longer than 100 characters.")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [StringLength(50, ErrorMessage = "Password must be between 6 and 50 characters.")]
        public string Password { get; set; }

        [Required]
        [Range(3, 5)]
        public byte UserTypeID { get; set; }

        public bool FirstLogin { get; set; } = true;
    }
}

using System.ComponentModel.DataAnnotations;

namespace EgyptMart.Services.CMSAPI.DTOS
{
    public class buissnessTypeCreateDto
    {
        [Required]
        public int BusinessTypeID { get; set; }
        [Required]
        public string BusinessTypeTitle { get; set; }
        [Required]
        public bool IsActive { get; set; }

    }
}

using System.ComponentModel.DataAnnotations;

namespace EgyptMart.Services.CMSAPI.DTOS
{
    public class CreateCompanyProfileDto
    {
        [Required]
        public Decimal Value { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace EgyptMart.Services.CMSAPI.DTOS.Country
{
    public class CreateCountryDto
    {
        [Required]
        [StringLength(100,MinimumLength = 2 )]
        public string CountryTitle { get; set; } = string.Empty;
    
    }
}

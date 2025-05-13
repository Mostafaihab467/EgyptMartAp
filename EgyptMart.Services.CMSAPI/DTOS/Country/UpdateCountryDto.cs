using System.ComponentModel.DataAnnotations;

namespace EgyptMart.Services.CMSAPI.DTOS.Country
{
    public class UpdateCountryDto
    {
        [Required]
        public long CountryID { get; set; } // BIGINT, Required for updates
        [Required]
        public string CountryTitle { get; set; } = string.Empty;
        [Required]
        public long? BaseId { get; set; } // Nullable BIGINT
        [Required]
        public byte? LangId { get; set; } // Nullable TINYINT
    }
}

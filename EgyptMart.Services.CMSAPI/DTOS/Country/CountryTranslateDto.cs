using System.ComponentModel.DataAnnotations;

namespace EgyptMart.Services.CMSAPI.DTOS.Country
{
    public class CountryTranslateDto
    {
        [Required]
        public string CountryTitle { get; set; }
        [Required]
        public int CountrtID { get; set; }
        [Required]
        public int LangID { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace EgyptMart.Services.CMSAPI.DTOS
{
    public class TranslateWidgetSliderDTO
    {


        [Required(ErrorMessage = "BaseID is required.")]
        public int BaseID { get; set; }

        [Required(ErrorMessage = "ShortTitle is required.")]
        [StringLength(50, ErrorMessage = "ShortTitle cannot be longer than 50 characters.")]
        public string ShortTitle { get; set; }

        [Required(ErrorMessage = "LangID is required")]
        [Range(0, 255)]
        public byte LangID { get; set; }
        [Required(ErrorMessage = "MainTitle is required.")]
        [StringLength(150, ErrorMessage = "MainTitle cannot be longer than 150 characters.")]
        public string MainTitle { get; set; }

        [Required(ErrorMessage = "Call2ActionMsg is required.")]
        [StringLength(30, ErrorMessage = "Call2ActionMsg cannot be longer than 30 characters.")]
        public string Call2ActionMsg { get; set; }
    }


}

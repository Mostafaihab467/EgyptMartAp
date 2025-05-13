using System.ComponentModel.DataAnnotations;

namespace EgyptMart.Services.CMSAPI.DTOS.LangTranslate
{
    public class LangList_TranslateToDto
    {
        [Required]
        public byte LangID { get; set; }
      
    }
}

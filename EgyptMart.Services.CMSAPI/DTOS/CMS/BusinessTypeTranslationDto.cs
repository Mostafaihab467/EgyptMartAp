using System.ComponentModel.DataAnnotations;

namespace EgyptMart.Services.CMSAPI.DTOS.CMS
{
    public class BusinessTypeTranslationDto
    {
        [Required]
        public short BusinessTypeID { get; set; }  // Foreign Key reference to Lup_BusinessTypeList
        [Required]
        public string BusinessTypeTitle { get; set; }
        [Required]
        public bool IsActive { get; set; }
        [Required]
        public byte LangID { get; set; }  // Foreign Key reference to Lup_LangList
        [Required]
        public short? BaseTypeID { get; set; }  // Nullable field
    }
}

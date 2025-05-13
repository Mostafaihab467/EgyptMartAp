#nullable disable
using System.ComponentModel.DataAnnotations;

namespace EgyptMart.Services.ProductsAPI.DTO
{
    public class EdiAttributeDTO
    {
        [Required(ErrorMessage = "AttributeID is required")]
        public long AttributeID { get; set; }
        
        [Required(ErrorMessage = "AttributeTitle is required")]
        public string AttributeTitle { get; set; }

        [Required(ErrorMessage = "AttributeTypeID is required")]
        public byte AttributeTypeID { get; set; }

        [Required(ErrorMessage = "ShowAcrossAllCategory is required")]
        [Range(0, 1, ErrorMessage = "ShowAcrossAllCategory must be true or false")]
        public bool ShowAcrossAllCategory { get; set; }
    }
}

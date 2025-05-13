using System.ComponentModel.DataAnnotations;

namespace EgyptMart.Services.ProductsAPI.DTO
{
    public class TranslateAttributeDTO
    {
        [Required]
        public int AttributeID { get; set; }
        [Required(ErrorMessage = "AttributeTitle Cannot Be Empty")]
        public string AttributeTitle { get; set; }
        [Required(ErrorMessage = "LangId Must Exist")]
        public byte LangID { get; set; } // TinyINT corresponds to byte in C#

    }
}

using System.ComponentModel.DataAnnotations;

namespace EgyptMart.Services.ProductsAPI.DTO
{
    public class GetCategoryByParentIDDTO
    {
        [Required]
        [Range(0, int.MaxValue)]
        public int ParentID { get; set; }
        [Required]
        [Range(0, byte.MaxValue)]
        public byte RepType { get; set; }

        [Required]
        [Range(1, byte.MaxValue)]
        public byte LangID { get; set; } = 1;

    }
}

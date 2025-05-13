using System.ComponentModel.DataAnnotations;

namespace EgyptMart.Services.ProductsAPI.DTO
{
    public class GetTopLevelDTO
    {
        [Range(0, byte.MaxValue)]
        public byte LangID { get; set; }

        [Range(0, byte.MaxValue)]
        public byte RepType { get; set; }
    }
}

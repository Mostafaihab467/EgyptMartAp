#nullable disable
using System.ComponentModel.DataAnnotations;

namespace EgyptMart.Services.ProductsAPI.DTO
{
    public class GenaricChangeStatusDTO
    {
        [Required]
        public Int64 RID { get; set; }
        [Required]
        public bool NewStatus { get; set; }
    }
}

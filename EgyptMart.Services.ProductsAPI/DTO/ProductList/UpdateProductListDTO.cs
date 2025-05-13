#nullable disable

using EgyptMart.Services.ProductsAPI.Validations;
using System.ComponentModel.DataAnnotations;

namespace EgyptMart.Services.ProductsAPI.DTO
{
    public class UpdateProductListDTO
    {
        [Required(ErrorMessage = "ProductsID is required")]
        public int ProductsID { get; set; }

        [Required(ErrorMessage = "ProductTitle is required")]
        public string ProductTitle { get; set; }

        [Required(ErrorMessage = "CategoryID is required")]
        public int CategoryID { get; set; }

        [Required(ErrorMessage = "SEOKey is required")]
        public string SEOKey { get; set; }

        [Required(ErrorMessage = "SKU is required")]
        public string SKU { get; set; }

        [Required(ErrorMessage = "GSCode is required")]
        public string GSCode { get; set; }
        public string ShortDesc { get; set; }
        [Required]
        public string MinimumOrder { get; set; }
        public string FullDesc { get; set; }

        [Range(0, 9999999.99, ErrorMessage = "Value must be between 0 and 999999999")]
        [CostValidation]
        public decimal CostBefore { get; set; }

        [Range(0, 9999999.99, ErrorMessage = "Value must be between 0 and 99999999")]
        public decimal CostAfter { get; set; }
    }
}

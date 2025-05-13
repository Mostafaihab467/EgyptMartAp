#nullable disable
using System.ComponentModel.DataAnnotations;
using EgyptMart.Services.ProductsAPI.Validations;

namespace EgyptMart.Services.ProductsAPI.DTO
{
    public class InsertProductListDTO
    {
        [Required(ErrorMessage = "OwnerID is required")]
        //[AuthUserValidator]
        public long OwnerID { get; set; }

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

        [MaxLength(140, ErrorMessage = "out of scope range")]
        public string ShortDesc { get; set; }

        [MaxLength(2000, ErrorMessage = "out of scope range")]
        public string FullDesc { get; set; }

        [MaxLength(int.MaxValue)]
        public string MinimumOrder { get; set; }

        [Range(0, 999999.99, ErrorMessage = "Value must be between 0 and 999999")]
        [CostValidation]

        public decimal CostBefore { get; set; }

        [Range(0, 999999.99, ErrorMessage = "Value must be between 0 and 999999.99.99.")]
        public decimal CostAfter { get; set; }

        [Required]
        [Range(0, 1000000, ErrorMessage = "StockSimpleCounter must be between 0 and 1,000,000")]
        public int StockSimpleCounter { get; set; } = 0;

        [Range(0, 1, ErrorMessage = "StockStatus must be true or false")]
        public bool StockStatus { get; set; } = false;
    }
}

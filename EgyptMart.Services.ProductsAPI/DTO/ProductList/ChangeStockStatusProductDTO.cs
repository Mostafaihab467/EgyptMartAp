using System.ComponentModel.DataAnnotations;

namespace EgyptMart.Services.ProductsAPI.DTO
{
    public class ChangeStockStatusProductDTO
    {
        [Required(ErrorMessage = "ProductID is required")]

        public long ProductsID { get; set; }

        [Required(ErrorMessage = "StockStatus is required")]
        [Range(0, 1, ErrorMessage = "StockStatus must be true or false")]
        public bool StockStatus { get; set; }

        [Required(ErrorMessage = "StockSimpleCounter is required")]
        [Range(0, int.MaxValue, ErrorMessage = "StockSimpleCounter must be between 0 and 1,000,000")]

        public int StockSimpleCounter { get; set; }
    }
}

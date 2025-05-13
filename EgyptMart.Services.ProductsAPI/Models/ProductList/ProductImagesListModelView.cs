#nullable disable
namespace EgyptMart.Services.ProductsAPI.Models.ProductList
{
    public class ProductImagesListModelView
    {
        public long ImageID { get; set; }
        public long ProductID { get; set; }
        public string ImageURL { get; set; }
        public bool IsThumbMain { get; set; }
        public bool IsMain { get; set; }
    }
}

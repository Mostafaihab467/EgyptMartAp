#nullable disable
namespace EgyptMart.Services.ProductsAPI.Models
{
    public class CategoryListModelView
    {
        public int CategoryID { get; set; }
        public string CategoryTitle { get; set; }
        public int ParentID { get; set; }
        public byte? LangID { get; set; }
        public short DisplayOrder { get; set; }
        public string CategoryImageURL { get; set; } = null;
        public int BaseID { get; set; }
        public bool IsActive { get; set; }
    }
}

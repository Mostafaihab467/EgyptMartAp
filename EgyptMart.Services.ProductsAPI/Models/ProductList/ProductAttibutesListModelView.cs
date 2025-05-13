#nullable disable
namespace EgyptMart.Services.ProductsAPI.Models
{
    public class ProductAttibutesListModelView
    {
        public long LinkID { get; set; }
        public long ProductID { get; set; }
        public int AttributeID { get; set; }
        public string AttributeTitle { get; set; }
        public string Value { get; set; }
        public byte LangID { get; set; }
        public short DisplayOrder { get; set; }
    }
}

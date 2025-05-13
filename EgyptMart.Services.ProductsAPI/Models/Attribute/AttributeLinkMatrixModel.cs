namespace EgyptMart.Services.ProductsAPI.Models
{
    public class AttributeLinkMatrixModel
    {
        public int CategoryID { get; set; }
        public string? CategoryTitle { get; set; }
        public int ParentID { get; set; }
        public byte LangID { get; set; }
        public short DisplayOrder { get; set; }
        public string? CategoryImageURL { get; set; }
        public bool IsActive { get; set; }
        public Int64? LinkID { get; set; }

    }
}

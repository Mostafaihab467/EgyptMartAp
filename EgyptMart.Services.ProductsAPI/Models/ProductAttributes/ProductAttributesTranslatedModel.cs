namespace EgyptMart.Services.ProductsAPI.Models
{
    public class ProductAttributesTranslatedModel
    {

        public int? AttributeID { get; set; }
        public string? AttributeTitle { get; set; }
        public short DisplayOrder { get; set; }  // smallint corresponds to short in C#
        public byte? LangID { get; set; }  // tinyint corresponds to byte in C#
        public long LinkID { get; set; }  // bigint corresponds to long in C#
        public long ProductID { get; set; }  // bigint corresponds to long in C#
        public string? Value { get; set; }  // nvarchar(max) corresponds to string


    }
}

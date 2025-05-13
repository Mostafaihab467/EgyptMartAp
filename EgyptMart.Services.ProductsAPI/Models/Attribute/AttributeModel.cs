namespace EgyptMart.Services.ProductsAPI.Models.Attribute
{


    public class AttributeModel
    {
        public int AttributeID { get; set; }
        public string AttributeTitle { get; set; }
        public byte LangID { get; set; }  // tinyint in SQL is mapped to byte in C#
        public byte AttributeTypeID { get; set; }  // tinyint in SQL is mapped to byte in C#
        public long BaseAttributeID { get; set; }  // bigint in SQL is mapped to long in C#
        public bool ShowAcrossAllCategory { get; set; }  // bit in SQL is mapped to bool in C#
        public bool IsActive { get; set; }  // bit in SQL is mapped to bool in C#
        public long? RcBy { get; set; }  // bigint in SQL is mapped to long in C#
    }
}

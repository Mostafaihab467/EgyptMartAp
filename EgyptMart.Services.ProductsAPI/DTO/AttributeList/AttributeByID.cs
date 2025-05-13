namespace EgyptMart.Services.ProductsAPI.DTO.AttributeList
{
    public class AttributeByID
    {

        public int AttributeID { get; set; }
        public string? AttributeTitle { get; set; }
        public byte LangID { get; set; }
        public byte AttributeTypeID { get; set; }
        public long BaseAttributeID { get; set; }
        public bool ShowAcrossAllCategory { get; set; }
        public bool IsActive { get; set; }
        public long? RcBy { get; set; }
    }
}

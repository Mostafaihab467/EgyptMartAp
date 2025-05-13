namespace EgyptMart.Services.CMSAPI.Models.FooterLink
{
    public class FooterLinkModel
    {
        public int? FooterItemID { get; set; }
        public string? FooterItemTitle { get; set; }
        public byte? LangID { get; set; }
        public int? BasID { get; set; }
        public int? ParentID { get; set; }
        public string? TargetUrl { get; set; }
        public bool? IsActive { get; set; }
        public short? DisplayOrder { get; set; }
        public byte? ColumnIndex { get; set; }
    }
}

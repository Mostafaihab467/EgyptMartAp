namespace EgyptMart.Services.CMSAPI.Models.WidgetHeaderMenue
{
    public class HeaderMenuModel
    {
        public int MenuItemID { get; set; }
        public string MenuItemTitle { get; set; }
        public byte LangID { get; set; }
        public int BasID { get; set; }
        public int? ParentID { get; set; }  // Nullable, if ParentID can be NULL
        public short DisplayOrder { get; set; }
        public string TargetUrl { get; set; }
    }
}

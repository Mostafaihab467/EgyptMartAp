namespace EgyptMart.Services.CMSAPI.Models.WidgetHeaderMenue
{
    public class WidgetsHeaderMenuGetTopLevelModel
    {
        public int MenuItemID { get; set; }
        public string MenuItemTitle { get; set; }
        public byte LangID { get; set; }  // Using byte for tinyint
        public int BasID { get; set; }
        public int ParentID { get; set; }
        public string TargetUrl { get; set; }
        public bool IsActive { get; set; }  // Using bool for bit
        public short DisplayOrder { get; set; }
    }
}

namespace EgyptMart.Services.CMSAPI.Models.WidgetsSocialMedia
{
    public class WidgetsSocialMediaGetModel
    {
        public short LinkID { get; set; } // Changed from int to short
        public string LinkTitle { get; set; }
        public string LinkTarget { get; set; }
        public short DisplayOrder { get; set; } // Ensure this matches the database type
        public string LinkIcon { get; set; }
        public bool IsActive { get; set; }
    }
}

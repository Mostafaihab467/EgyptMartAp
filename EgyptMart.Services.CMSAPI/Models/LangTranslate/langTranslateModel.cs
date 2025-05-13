namespace EgyptMart.Services.CMSAPI.Models.LangTranslate
{
    public class langTranslateModel
    {
        public byte LangID { get; set; }
        public string LangTitle { get; set; } // FIXED: "LangTitle" instead of "LangeTitle"
        public string Direction { get; set; }
    }
}

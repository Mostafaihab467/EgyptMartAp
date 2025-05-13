namespace EgyptMart.Services.CMSAPI.Models
{
    public class WidgetSliderModel
    {

        public short SliderID { get; set; }
        public string ShortTitle { get; set; }
        public string MainTitle { get; set; }
        public string Call2ActionMsg { get; set; }
        public string ImageURL { get; set; }
        public string Call2ActionURL { get; set; }
        public short DisplayOrder { get; set; }
        public short BaseID { get; set; }
        public byte LangID { get; set; }
        public bool IsActive { get; set; }


    }
}

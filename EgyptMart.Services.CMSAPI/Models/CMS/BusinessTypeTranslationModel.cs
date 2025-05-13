namespace EgyptMart.Services.CMSAPI.Models
{
    public class BusinessTypeTranslationModel
    {
        public short BusinessTypeID { get; set; }
        public string BusinessTypeTitle { get; set; }
        public bool IsActive { get; set; }
        public short? BaseTypeID { get; set; }
    }
}

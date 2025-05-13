namespace EgyptMart.Services.CMSAPI.Models
{
    public class WidgetFAQModel
    {
        public int QID { get; set; }  // int in SQL

        public string QTitle { get; set; }  // nvarchar in SQL

        public string QAnswer { get; set; } // nvarchar in SQL

        public byte? LangID { get; set; }  // tinyint in SQL

        public int? BaseID { get; set; }  // int in SQL

        public bool IsActive { get; set; }  // bit in SQL

        public short DisplayOrder { get; set; }  // smallint in SQL
    }
}

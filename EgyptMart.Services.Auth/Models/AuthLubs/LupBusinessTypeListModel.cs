namespace EgyptMart.Services.Auth.Models
{
    public class LupBusinessTypeListModel
    {
        public short BusinessTypeID { get; set; }


        public string BusinessTypeTitle { get; set; }


        public bool IsActive { get; set; }


        public byte LangID { get; set; }


        public short BaseTypeID { get; set; }
    }
}

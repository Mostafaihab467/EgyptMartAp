

namespace EgyptMart.Services.CMSAPI.ViewModel
{
    public class WishListViewModel
    {

        public Int64 RecordID { get; set; }

        public Int64 UserID { get; set; }

        public Int64 ProductID { get; set; }

        public DateTime AddDate { get; set; }
        public byte LangID { get; set; }

        public string ProductTitle { get; set; }

        public decimal CostBefore { get; set; }
        public decimal CostAfter { get; set; }
        public string? ImageURL { get; set; }
    }
}




namespace EgyptMart.Services.CMSAPI.Models
{
    public class ContactCustomerListModel
    {
        public long ContactID { get; set; }
        public long CustomerID { get; set; }
        public long SupplierID { get; set; }

        public string? Title { get; set; }
        public string? Body { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime? LastUpdateAt { get; set; }

        public string? CustomerDisplayName { get; set; }
        public string? CustomerUserName { get; set; }
        public string? CustomerProfileImage { get; set; }

        public string? SupplierDisplayName { get; set; }
        public string? SupplierUserName { get; set; }
        public string? SupplierProfileImage { get; set; }
    }
}

namespace EgyptMart.Services.CMSAPI.Models
{
    public class ContactCustomerReplysModel
    {
        public long ReplyID { get; set; }
        public long ContactID { get; set; }
        public long CustomerID { get; set; }

        public string? ReplyBody { get; set; }
        public string? Body { get; set; }

        public bool IsReplyed { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime? ReplyAt { get; set; }

        public string? CustomerDisplayName { get; set; }
        public string? CustomerUserName { get; set; }
        public string? CustomerProfileImage { get; set; }
    }
}

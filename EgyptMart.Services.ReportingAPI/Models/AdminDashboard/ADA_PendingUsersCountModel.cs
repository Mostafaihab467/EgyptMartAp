namespace EgyptMart.Services.ReportingAPI.Models
{
    public class ADA_PendingUsersCountModel
    {
        public byte UserTypeID { get; set; } // tinyint
        public string UserType
        {
            get
            {
                return UserTypeID switch
                {
                    1 => "Customer",
                    2 => "Supplier",
                    _ => "Unknown"
                };
            }
        }
        public int PendingCount { get; set; } // int
    }
}

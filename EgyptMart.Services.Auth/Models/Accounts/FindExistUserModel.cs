namespace EgyptMart.Services.Auth.Models
{
    public class FindExistUserModel
    {
        public long UserID { get; set; } // bigint
        public bool FirstLogin { get; set; } // bit
        public byte FailLoginCount { get; set; } // tinyint
        public int MaxTrysCount { get; set; } // int
        public byte UserTypeID { get; set; }
    }
}

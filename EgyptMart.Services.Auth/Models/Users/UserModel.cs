namespace EgyptMart.Services.Auth.Models
{
    public class UserModel
    {

        public long UserID { get; set; }
        public byte UserTypeID { get; set; }
        public string DisplayName { get; set; }
        public string UserName { get; set; }
        public string? ProfileImage { get; set; }
        public bool IsVerfied { get; set; }
        public bool IsActive { get; set; }
        public bool FirstLogin { get; set; }
        public byte FailLoginCount { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsDeletable { get; set; }
        public DateTime? RCDate { get; set; }
        public short? RCBy { get; set; }
        public DateTime? LADate { get; set; }
        public short? LABy { get; set; }
        public string? VersionNo { get; set; }
        public long VerfiedBy { get; set; }
        public DateTime? VerficationDate { get; set; } // Nullable because it can be null in some cases
        public byte? VerificationStatus { get; set; }


    }
}
